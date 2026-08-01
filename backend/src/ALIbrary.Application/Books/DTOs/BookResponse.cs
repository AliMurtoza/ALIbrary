namespace ALIbrary.Application.Books.DTOs;

public class BookResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public int PublishedYear { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public Guid PublisherId { get; set; }

    public string PublisherName { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }

    public string LanguageName { get; set; } = string.Empty;
}