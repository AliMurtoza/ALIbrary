using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.UserBooks.DTOs;

public class UpdateUserBookRequest
{
    public ReadingStatus ReadingStatus { get; set; }

    public bool IsFavorite { get; set; }
}