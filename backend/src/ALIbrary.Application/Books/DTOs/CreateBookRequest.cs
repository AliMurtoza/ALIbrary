namespace ALIbrary.Application.Books.DTOs;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Guid PublisherId { get; set; }

    public Guid LanguageId { get; set; }

    public string ISBN { get; set; } = string.Empty;

    public int PublishedYear { get; set; }

    public string Description { get; set; } = string.Empty;
}