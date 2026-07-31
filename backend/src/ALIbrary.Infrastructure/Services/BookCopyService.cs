using ALIbrary.Application.BookCopies.DTOs;
using ALIbrary.Application.BookCopies.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Domain.Enums;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class BookCopyService : IBookCopyService
{
    private readonly ApplicationDbContext _context;

    public BookCopyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookCopyResponse> CreateAsync(CreateBookCopyRequest request)
    {
        var book = await _context.Books.FindAsync(request.BookId);

        if (book == null)
            throw new Exception("Book not found.");

        var copy = new BookCopy
        {
            Barcode = request.Barcode,
            ShelfLocation = request.ShelfLocation,
            Condition = request.Condition,
            Status = BookCopyStatus.Available,
            BookId = request.BookId
        };

        _context.BookCopies.Add(copy);

        await _context.SaveChangesAsync();

        return new BookCopyResponse
        {
            Id = copy.Id,
            Barcode = copy.Barcode,
            ShelfLocation = copy.ShelfLocation,
            Condition = copy.Condition,
            Status = copy.Status,
            BookId = copy.BookId,
            BookTitle = book.Title
        };
    }

    public async Task<List<BookCopyResponse>> GetAllAsync()
    {
        return await _context.BookCopies
            .Include(c => c.Book)
            .Select(c => new BookCopyResponse
            {
                Id = c.Id,
                Barcode = c.Barcode,
                ShelfLocation = c.ShelfLocation,
                Condition = c.Condition,
                Status = c.Status,
                BookId = c.BookId,
                BookTitle = c.Book.Title
            })
            .ToListAsync();
    }

    public async Task<BookCopyResponse?> GetByIdAsync(Guid id)
    {
        return await _context.BookCopies
            .Include(c => c.Book)
            .Where(c => c.Id == id)
            .Select(c => new BookCopyResponse
            {
                Id = c.Id,
                Barcode = c.Barcode,
                ShelfLocation = c.ShelfLocation,
                Condition = c.Condition,
                Status = c.Status,
                BookId = c.BookId,
                BookTitle = c.Book.Title
            })
            .FirstOrDefaultAsync();
    }

    public async Task<BookCopyResponse?> UpdateAsync(Guid id, UpdateBookCopyRequest request)
    {
        var copy = await _context.BookCopies
            .Include(c => c.Book)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (copy == null)
            return null;

        copy.Barcode = request.Barcode;
        copy.ShelfLocation = request.ShelfLocation;
        copy.Condition = request.Condition;
        copy.Status = request.Status;

        await _context.SaveChangesAsync();

        return new BookCopyResponse
        {
            Id = copy.Id,
            Barcode = copy.Barcode,
            ShelfLocation = copy.ShelfLocation,
            Condition = copy.Condition,
            Status = copy.Status,
            BookId = copy.BookId,
            BookTitle = copy.Book.Title
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var copy = await _context.BookCopies.FindAsync(id);

        if (copy == null)
            return false;

        _context.BookCopies.Remove(copy);

        await _context.SaveChangesAsync();

        return true;
    }
}