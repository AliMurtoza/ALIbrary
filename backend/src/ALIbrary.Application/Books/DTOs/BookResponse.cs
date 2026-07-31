namespace ALIbrary.Application.Books.DTOs;

public class BookResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public int PublishedYear { get; set; }
}