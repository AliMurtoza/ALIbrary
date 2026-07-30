using ALIbrary.Domain.Common;
using ALIbrary.Domain.Enums;

namespace ALIbrary.Domain.Entities;

public class BookCopy : BaseEntity
{
    public string Barcode { get; set; } = string.Empty;

    public string? ShelfLocation { get; set; }

    public BookCopyCondition Condition { get; set; }

    public BookCopyStatus Status { get; set; }

    public Guid BookId { get; set; }

    public Book Book { get; set; } = null!;

    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}