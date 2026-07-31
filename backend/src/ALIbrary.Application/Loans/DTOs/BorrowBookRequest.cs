namespace ALIbrary.Application.Loans.DTOs;

public class BorrowBookRequest
{
    public Guid MemberId { get; set; }

    public Guid BookCopyId { get; set; }
}