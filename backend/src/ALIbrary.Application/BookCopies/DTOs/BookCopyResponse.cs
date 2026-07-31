using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.BookCopies.DTOs;

public class BookCopyResponse
{
    public Guid Id { get; set; }

    public string Barcode { get; set; } = string.Empty;

    public string? ShelfLocation { get; set; }

    public BookCopyCondition Condition { get; set; }

    public BookCopyStatus Status { get; set; }

    public Guid BookId { get; set; }

    public string BookTitle { get; set; } = string.Empty;
}