namespace ALIbrary.Application.BookReviews.DTOs;

public class UpdateBookReviewRequest
{
    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Review { get; set; }
}