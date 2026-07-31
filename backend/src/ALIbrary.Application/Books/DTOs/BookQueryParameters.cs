namespace ALIbrary.Application.Books.DTOs;

public class BookQueryParameters
{
    public string? Search { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? PublisherId { get; set; }

    public Guid? LanguageId { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}