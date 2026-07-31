namespace ALIbrary.Application.BookReviews.DTOs;

public class BookReviewResponse
{
    public Guid Id { get; set; }

    public Guid UserBookId { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Review { get; set; }
}