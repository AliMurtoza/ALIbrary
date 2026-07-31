using ALIbrary.Application.BookReviews.DTOs;

namespace ALIbrary.Application.BookReviews.Interfaces;

public interface IBookReviewService
{
    Task<BookReviewResponse> CreateAsync(CreateBookReviewRequest request);

    Task<BookReviewResponse?> UpdateAsync(Guid id, UpdateBookReviewRequest request);

    Task<List<BookReviewResponse>> GetAllAsync();

    Task<BookReviewResponse?> GetByIdAsync(Guid id);
}