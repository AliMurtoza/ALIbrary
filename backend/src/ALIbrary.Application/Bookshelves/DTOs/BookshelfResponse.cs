namespace ALIbrary.Application.Bookshelves.DTOs;

public class BookshelfResponse
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}