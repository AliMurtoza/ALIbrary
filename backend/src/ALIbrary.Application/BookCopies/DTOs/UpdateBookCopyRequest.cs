using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.BookCopies.DTOs;

public class UpdateBookCopyRequest
{
    public string Barcode { get; set; } = string.Empty;

    public string? ShelfLocation { get; set; }

    public BookCopyCondition Condition { get; set; }

    public BookCopyStatus Status { get; set; }
}