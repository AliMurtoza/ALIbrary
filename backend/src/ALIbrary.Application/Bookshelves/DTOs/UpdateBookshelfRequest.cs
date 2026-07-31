namespace ALIbrary.Application.Bookshelves.DTOs;

public class UpdateBookshelfRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}