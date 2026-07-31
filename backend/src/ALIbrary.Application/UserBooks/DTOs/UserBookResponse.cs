using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.UserBooks.DTOs;

public class UserBookResponse
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public ReadingStatus ReadingStatus { get; set; }

    public bool IsFavorite { get; set; }
}