namespace ALIbrary.Application.ReadingProgress.DTOs;

public class ReadingProgressResponse
{
    public Guid Id { get; set; }

    public Guid UserBookId { get; set; }

    public int CurrentPage { get; set; }

    public DateTime? StartedReadingAt { get; set; }

    public DateTime? FinishedReadingAt { get; set; }

    public DateTime? LastUpdatedAt { get; set; }
}