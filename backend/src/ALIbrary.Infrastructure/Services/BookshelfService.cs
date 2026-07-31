using ALIbrary.Application.Bookshelves.DTOs;
using ALIbrary.Application.Bookshelves.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
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
            throw new Exception("Member not found.");

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
}