using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.BookCopies.DTOs;

public class CreateBookCopyRequest
{
    public string Barcode { get; set; } = string.Empty;

    public string? ShelfLocation { get; set; }

    public BookCopyCondition Condition { get; set; }

    public Guid BookId { get; set; }
}