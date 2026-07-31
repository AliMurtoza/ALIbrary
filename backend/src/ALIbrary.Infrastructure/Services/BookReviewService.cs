using ALIbrary.Application.BookReviews.DTOs;
using ALIbrary.Application.BookReviews.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class BookReviewService : IBookReviewService
{
    private readonly ApplicationDbContext _context;

    public BookReviewService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BookReviewResponse> CreateAsync(CreateBookReviewRequest request)
    {
        var userBook = await _context.UserBooks
            .Include(u => u.Book)
            .FirstOrDefaultAsync(u => u.Id == request.UserBookId);

        if (userBook == null)
            throw new NotFoundException("UserBook not found.");

        var exists = await _context.BookReviews
            .AnyAsync(r => r.UserBookId == request.UserBookId);

        if (exists)
            throw new BadRequestException("Review already exists.");

        var review = new BookReview
        {
            UserBookId = request.UserBookId,
            Rating = request.Rating,
            Title = request.Title,
            Review = request.Review
        };

        _context.BookReviews.Add(review);

        userBook.Book.TotalRatings++;

        userBook.Book.AverageRating =
            ((userBook.Book.AverageRating * (userBook.Book.TotalRatings - 1))
            + review.Rating)
            / userBook.Book.TotalRatings;

        await _context.SaveChangesAsync();

        return new BookReviewResponse
        {
            Id = review.Id,
            UserBookId = review.UserBookId,
            BookTitle = userBook.Book.Title,
            Rating = review.Rating,
            Title = review.Title,
            Review = review.Review
        };
    }

    public async Task<BookReviewResponse?> UpdateAsync(Guid id, UpdateBookReviewRequest request)
    {
        var review = await _context.BookReviews
            .Include(r => r.UserBook)
                .ThenInclude(u => u.Book)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (review == null)
            return null;

        var book = review.UserBook.Book;

        book.AverageRating =
            ((book.AverageRating * book.TotalRatings)
            - review.Rating
            + request.Rating)
            / book.TotalRatings;

        review.Rating = request.Rating;
        review.Title = request.Title;
        review.Review = request.Review;

        await _context.SaveChangesAsync();

        return new BookReviewResponse
        {
            Id = review.Id,
            UserBookId = review.UserBookId,
            BookTitle = book.Title,
            Rating = review.Rating,
            Title = review.Title,
            Review = review.Review
        };
    }

    public async Task<List<BookReviewResponse>> GetAllAsync()
    {
        return await _context.BookReviews
            .Include(r => r.UserBook)
                .ThenInclude(u => u.Book)
            .Select(r => new BookReviewResponse
            {
                Id = r.Id,
                UserBookId = r.UserBookId,
                BookTitle = r.UserBook.Book.Title,
                Rating = r.Rating,
                Title = r.Title,
                Review = r.Review
            })
            .ToListAsync();
    }

    public async Task<BookReviewResponse?> GetByIdAsync(Guid id)
    {
        return await _context.BookReviews
            .Include(r => r.UserBook)
                .ThenInclude(u => u.Book)
            .Where(r => r.Id == id)
            .Select(r => new BookReviewResponse
            {
                Id = r.Id,
                UserBookId = r.UserBookId,
                BookTitle = r.UserBook.Book.Title,
                Rating = r.Rating,
                Title = r.Title,
                Review = r.Review
            })
            .FirstOrDefaultAsync();
    }
}