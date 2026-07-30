using ALIbrary.Domain.Common;
using ALIbrary.Domain.Enums;

namespace ALIbrary.Domain.Entities;

public class Loan : BaseEntity
{
    public Guid MemberId { get; set; }

    public Guid BookCopyId { get; set; }

    public DateTime BorrowedAt { get; set; }

    public DateTime DueAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public LoanStatus Status { get; set; }

    public Member Member { get; set; } = null!;

    public BookCopy BookCopy { get; set; } = null!;
}