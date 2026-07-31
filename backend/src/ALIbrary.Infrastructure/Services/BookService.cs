using ALIbrary.Application.Books.DTOs;
using ALIbrary.Application.Books.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
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
            ISBN = request.ISBN,
            PublicationYear = request.PublishedYear,
            Description = request.Description
        };

        _context.Books.Add(book);

        await _context.SaveChangesAsync();

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublishedYear = book.PublicationYear
        };
    }

    public async Task<List<BookResponse>> GetAllAsync()
    {
        return await _context.Books
            .Select(book => new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedYear = book.PublicationYear
            })
            .ToListAsync();
    }

    public async Task<BookResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Books
            .Where(book => book.Id == id)
            .Select(book => new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedYear = book.PublicationYear
            })
            .FirstOrDefaultAsync();
    }

    public async Task<BookResponse?> UpdateAsync(Guid id, UpdateBookRequest request)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
            return null;

        book.Title = request.Title;
        book.PublisherId = request.PublisherId;
        book.LanguageId = request.LanguageId;
        book.ISBN = request.ISBN;
        book.PublicationYear = request.PublishedYear;
        book.Description = request.Description;

        await _context.SaveChangesAsync();

        return new BookResponse
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublishedYear = book.PublicationYear
        };
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