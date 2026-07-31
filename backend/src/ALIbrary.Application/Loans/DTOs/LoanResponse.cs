using ALIbrary.Domain.Enums;

namespace ALIbrary.Application.Loans.DTOs;

public class LoanResponse
{
    public Guid Id { get; set; }

    public Guid MemberId { get; set; }

    public Guid BookCopyId { get; set; }

    public string BookTitle { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public DateTime BorrowedAt { get; set; }

    public DateTime DueAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public LoanStatus Status { get; set; }
}