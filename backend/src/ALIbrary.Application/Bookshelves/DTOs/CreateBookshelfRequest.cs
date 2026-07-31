namespace ALIbrary.Application.Bookshelves.DTOs;

public class CreateBookshelfRequest
{
    public Guid MemberId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}