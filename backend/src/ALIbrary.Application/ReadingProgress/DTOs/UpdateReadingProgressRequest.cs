namespace ALIbrary.Application.ReadingProgress.DTOs;

public class UpdateReadingProgressRequest
{
    public int CurrentPage { get; set; }

    public DateTime? StartedReadingAt { get; set; }

    public DateTime? FinishedReadingAt { get; set; }
}