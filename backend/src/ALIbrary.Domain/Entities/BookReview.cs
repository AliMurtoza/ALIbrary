using ALIbrary.Domain.Common;

namespace ALIbrary.Domain.Entities;

public class BookReview : BaseEntity
{
    public Guid UserBookId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Review { get; set; }

    public UserBook UserBook { get; set; } = null!;
}