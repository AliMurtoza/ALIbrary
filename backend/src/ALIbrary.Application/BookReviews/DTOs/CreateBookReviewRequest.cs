namespace ALIbrary.Application.BookReviews.DTOs;

public class CreateBookReviewRequest
{
    public Guid UserBookId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Review { get; set; }
}