using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.UserBooks.DTOs;

public class CreateUserBookRequest
{
    public Guid MemberId { get; set; }

    public Guid BookId { get; set; }

    public ReadingStatus ReadingStatus { get; set; }

    public bool IsFavorite { get; set; }
}