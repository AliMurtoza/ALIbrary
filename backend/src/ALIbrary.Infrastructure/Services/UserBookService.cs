using ALIbrary.Application.UserBooks.DTOs;
using ALIbrary.Application.UserBooks.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class UserBookService : IUserBookService
{
    private readonly ApplicationDbContext _context;

    public UserBookService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserBookResponse> CreateAsync(CreateUserBookRequest request)
    {
        var member = await _context.Members.FindAsync(request.MemberId);

        if (member == null)
            throw new Exception("Member not found.");

        var book = await _context.Books.FindAsync(request.BookId);

        if (book == null)
            throw new Exception("Book not found.");

        var userBook = new UserBook
        {
            MemberId = request.MemberId,
            BookId = request.BookId,
            ReadingStatus = request.ReadingStatus,
            IsFavorite = request.IsFavorite
        };

        _context.UserBooks.Add(userBook);

        await _context.SaveChangesAsync();

        return new UserBookResponse
        {
            Id = userBook.Id,
            MemberId = userBook.MemberId,
            BookId = userBook.BookId,
            BookTitle = book.Title,
            ReadingStatus = userBook.ReadingStatus,
            IsFavorite = userBook.IsFavorite
        };
    }

    public async Task<UserBookResponse?> UpdateAsync(Guid id, UpdateUserBookRequest request)
    {
        var userBook = await _context.UserBooks
            .Include(u => u.Book)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (userBook == null)
            return null;

        userBook.ReadingStatus = request.ReadingStatus;
        userBook.IsFavorite = request.IsFavorite;

        await _context.SaveChangesAsync();

        return new UserBookResponse
        {
            Id = userBook.Id,
            MemberId = userBook.MemberId,
            BookId = userBook.BookId,
            BookTitle = userBook.Book.Title,
            ReadingStatus = userBook.ReadingStatus,
            IsFavorite = userBook.IsFavorite
        };
    }

    public async Task<List<UserBookResponse>> GetAllAsync()
    {
        return await _context.UserBooks
            .Include(u => u.Book)
            .Select(u => new UserBookResponse
            {
                Id = u.Id,
                MemberId = u.MemberId,
                BookId = u.BookId,
                BookTitle = u.Book.Title,
                ReadingStatus = u.ReadingStatus,
                IsFavorite = u.IsFavorite
            })
            .ToListAsync();
    }

    public async Task<UserBookResponse?> GetByIdAsync(Guid id)
    {
        return await _context.UserBooks
            .Include(u => u.Book)
            .Where(u => u.Id == id)
            .Select(u => new UserBookResponse
            {
                Id = u.Id,
                MemberId = u.MemberId,
                BookId = u.BookId,
                BookTitle = u.Book.Title,
                ReadingStatus = u.ReadingStatus,
                IsFavorite = u.IsFavorite
            })
            .FirstOrDefaultAsync();
    }
}