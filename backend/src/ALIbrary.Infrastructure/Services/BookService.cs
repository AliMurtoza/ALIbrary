using ALIbrary.Application.Books.DTOs;
using ALIbrary.Application.Books.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _context;

    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookResponse> CreateAsync(CreateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
            PublisherId = request.PublisherId,
            LanguageId = request.LanguageId,
            CategoryId = request.CategoryId,
            ISBN = request.ISBN,
            PublicationYear = request.PublishedYear,
            Description = request.Description
        };

        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return await GetByIdAsync(book.Id)
                    ?? throw new BadRequestException("Book created but could not be loaded.");
    }

    public async Task<List<BookResponse>> GetAllAsync(BookQueryParameters query)
    {
        var books = _context.Books
            .Include(b => b.Category)
            .Include(b => b.Publisher)
            .Include(b => b.Language)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            books = books.Where(b =>
                b.Title.ToLower().Contains(query.Search.ToLower()) ||
                b.ISBN.ToLower().Contains(query.Search.ToLower()));
        }

        if (query.CategoryId.HasValue)
        {
            books = books.Where(b => b.CategoryId == query.CategoryId);
        }

        if (query.PublisherId.HasValue)
        {
            books = books.Where(b => b.PublisherId == query.PublisherId);
        }

        if (query.LanguageId.HasValue)
        {
            books = books.Where(b => b.LanguageId == query.LanguageId);
        }

        books = books
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize);

        return await books
            .Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublishedYear = b.PublicationYear,
                Description = b.Description ?? string.Empty,

                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,

                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,

                LanguageId = b.LanguageId,
                LanguageName = b.Language.Name
            })
            .ToListAsync();
            }

    public async Task<BookResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Books
            .Include(b => b.Category)
            .Include(b => b.Publisher)
            .Include(b => b.Language)
            .Where(b => b.Id == id)
            .Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublishedYear = b.PublicationYear,
                Description = b.Description ?? string.Empty,

                CategoryId = b.CategoryId,
                CategoryName = b.Category.Name,

                PublisherId = b.PublisherId,
                PublisherName = b.Publisher.Name,

                LanguageId = b.LanguageId,
                LanguageName = b.Language.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task<BookResponse?> UpdateAsync(Guid id, UpdateBookRequest request)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return null;

        book.Title = request.Title;
        book.CategoryId = request.CategoryId;
        book.PublisherId = request.PublisherId;
        book.LanguageId = request.LanguageId;
        book.ISBN = request.ISBN;
        book.PublicationYear = request.PublishedYear;
        book.Description = request.Description;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(book.Id);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return false;

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return true;
    }
}