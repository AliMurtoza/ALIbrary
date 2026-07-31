using ALIbrary.Application.Bookshelves.DTOs;
using ALIbrary.Application.Bookshelves.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class BookshelfService : IBookshelfService
{
    private readonly ApplicationDbContext _context;

    public BookshelfService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookshelfResponse> CreateAsync(CreateBookshelfRequest request)
    {
        var member = await _context.Members.FindAsync(request.MemberId);

        if (member == null)
            throw new NotFoundException("Member not found.");

        var bookshelf = new Bookshelf
        {
            MemberId = request.MemberId,
            Name = request.Name,
            Description = request.Description
        };

        _context.Bookshelves.Add(bookshelf);

        await _context.SaveChangesAsync();

        return new BookshelfResponse
        {
            Id = bookshelf.Id,
            MemberId = bookshelf.MemberId,
            Name = bookshelf.Name,
            Description = bookshelf.Description
        };
    }

    public async Task<BookshelfResponse?> UpdateAsync(
        Guid id,
        UpdateBookshelfRequest request)
    {
        var bookshelf = await _context.Bookshelves.FindAsync(id);

        if (bookshelf == null)
            return null;

        bookshelf.Name = request.Name;
        bookshelf.Description = request.Description;

        await _context.SaveChangesAsync();

        return new BookshelfResponse
        {
            Id = bookshelf.Id,
            MemberId = bookshelf.MemberId,
            Name = bookshelf.Name,
            Description = bookshelf.Description
        };
    }

    public async Task<List<BookshelfResponse>> GetAllAsync()
    {
        return await _context.Bookshelves
            .Select(b => new BookshelfResponse
            {
                Id = b.Id,
                MemberId = b.MemberId,
                Name = b.Name,
                Description = b.Description
            })
            .ToListAsync();
    }

    public async Task<BookshelfResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Bookshelves
            .Where(b => b.Id == id)
            .Select(b => new BookshelfResponse
            {
                Id = b.Id,
                MemberId = b.MemberId,
                Name = b.Name,
                Description = b.Description
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var bookshelf = await _context.Bookshelves.FindAsync(id);

        if (bookshelf == null)
            return false;

        _context.Bookshelves.Remove(bookshelf);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task AddBookAsync(
    Guid bookshelfId,
    AddBookToShelfRequest request)
    {
        var shelf = await _context.Bookshelves.FindAsync(bookshelfId);

        if (shelf == null)
            throw new NotFoundException("Bookshelf not found.");

        var userBook = await _context.UserBooks.FindAsync(request.UserBookId);

        if (userBook == null)
            throw new NotFoundException("UserBook not found.");

        var exists = await _context.BookshelfBooks.AnyAsync(x =>
            x.BookshelfId == bookshelfId &&
            x.UserBookId == request.UserBookId);

        if (exists)
            throw new BadRequestException("Book already exists in shelf.");

        _context.BookshelfBooks.Add(new BookshelfBook
        {
            BookshelfId = bookshelfId,
            UserBookId = request.UserBookId
        });

        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoveBookAsync(
    Guid bookshelfId,
    Guid userBookId)
    {
        var item = await _context.BookshelfBooks
            .FirstOrDefaultAsync(x =>
                x.BookshelfId == bookshelfId &&
                x.UserBookId == userBookId);

        if (item == null)
            return false;

        _context.BookshelfBooks.Remove(item);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<BookshelfBookResponse>> GetBooksAsync(Guid bookshelfId)
    {
        return await _context.BookshelfBooks
            .Include(x => x.UserBook)
                .ThenInclude(ub => ub.Book)
            .Where(x => x.BookshelfId == bookshelfId)
            .Select(x => new BookshelfBookResponse
            {
                UserBookId = x.UserBookId,
                BookId = x.UserBook.BookId,
                BookTitle = x.UserBook.Book.Title,
                IsFavorite = x.UserBook.IsFavorite
            })
            .ToListAsync();
    }
}