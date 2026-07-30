using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class ReadingProgress : BaseEntity
{
    public Guid UserBookId { get; set; }

    public int CurrentPage { get; set; }

    public DateTime? StartedReadingAt { get; set; }

    public DateTime? FinishedReadingAt { get; set; }

    public DateTime? LastUpdatedAt { get; set; }

    public UserBook UserBook { get; set; } = null!;
}