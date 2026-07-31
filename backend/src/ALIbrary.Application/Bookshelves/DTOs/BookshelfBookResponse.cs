namespace ALIbrary.Application.Bookshelves.DTOs;

public class BookshelfBookResponse
{
    public Guid UserBookId { get; set; }

    public Guid BookId { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public bool IsFavorite { get; set; }
}