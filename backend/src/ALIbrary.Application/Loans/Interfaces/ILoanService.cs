using ALIbrary.Application.Loans.DTOs;

namespace ALIbrary.Application.Loans.Interfaces;

public interface ILoanService
{
    Task<LoanResponse> BorrowAsync(BorrowBookRequest request);

    Task<LoanResponse?> ReturnAsync(Guid loanId);

    Task<List<LoanResponse>> GetAllAsync();

    Task<LoanResponse?> GetByIdAsync(Guid id);
}