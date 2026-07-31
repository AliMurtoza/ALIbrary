using ALIbrary.Application.Loans.DTOs;
using ALIbrary.Application.Loans.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Domain.Enums;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class LoanService : ILoanService
{
    private readonly ApplicationDbContext _context;

    public LoanService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LoanResponse> BorrowAsync(BorrowBookRequest request)
    {
        var member = await _context.Members.FindAsync(request.MemberId);

        if (member == null)
            throw new NotFoundException("Member not found.");

        var copy = await _context.BookCopies
            .Include(c => c.Book)
            .FirstOrDefaultAsync(c => c.Id == request.BookCopyId);

        if (copy == null)
            throw new NotFoundException("Book copy not found.");

        if (copy.Status != BookCopyStatus.Available)
            throw new BadRequestException("Book copy is not available.");

        var loan = new Loan
        {
            MemberId = request.MemberId,
            BookCopyId = request.BookCopyId,
            BorrowedAt = DateTime.UtcNow,
            DueAt = DateTime.UtcNow.AddDays(14),
            Status = LoanStatus.Active
        };

        copy.Status = BookCopyStatus.Borrowed;

        _context.Loans.Add(loan);

        await _context.SaveChangesAsync();

        return new LoanResponse
        {
            Id = loan.Id,
            MemberId = loan.MemberId,
            BookCopyId = loan.BookCopyId,
            BookTitle = copy.Book.Title,
            Barcode = copy.Barcode,
            BorrowedAt = loan.BorrowedAt,
            DueAt = loan.DueAt,
            ReturnedAt = loan.ReturnedAt,
            Status = loan.Status
        };
    }

    public async Task<LoanResponse?> ReturnAsync(Guid loanId)
    {
        var loan = await _context.Loans
            .Include(l => l.BookCopy)
                .ThenInclude(c => c.Book)
            .FirstOrDefaultAsync(l => l.Id == loanId);

        if (loan == null)
            return null;

        if (loan.Status != LoanStatus.Active)
            throw new BadRequestException("Loan is already closed.");

        loan.ReturnedAt = DateTime.UtcNow;
        loan.Status = LoanStatus.Returned;

        loan.BookCopy.Status = BookCopyStatus.Available;

        await _context.SaveChangesAsync();

        return new LoanResponse
        {
            Id = loan.Id,
            MemberId = loan.MemberId,
            BookCopyId = loan.BookCopyId,
            BookTitle = loan.BookCopy.Book.Title,
            Barcode = loan.BookCopy.Barcode,
            BorrowedAt = loan.BorrowedAt,
            DueAt = loan.DueAt,
            ReturnedAt = loan.ReturnedAt,
            Status = loan.Status
        };
    }

    public async Task<List<LoanResponse>> GetAllAsync()
    {
        return await _context.Loans
            .Include(l => l.BookCopy)
                .ThenInclude(c => c.Book)
            .Select(l => new LoanResponse
            {
                Id = l.Id,
                MemberId = l.MemberId,
                BookCopyId = l.BookCopyId,
                BookTitle = l.BookCopy.Book.Title,
                Barcode = l.BookCopy.Barcode,
                BorrowedAt = l.BorrowedAt,
                DueAt = l.DueAt,
                ReturnedAt = l.ReturnedAt,
                Status = l.Status
            })
            .ToListAsync();
    }

    public async Task<LoanResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Loans
            .Include(l => l.BookCopy)
                .ThenInclude(c => c.Book)
            .Where(l => l.Id == id)
            .Select(l => new LoanResponse
            {
                Id = l.Id,
                MemberId = l.MemberId,
                BookCopyId = l.BookCopyId,
                BookTitle = l.BookCopy.Book.Title,
                Barcode = l.BookCopy.Barcode,
                BorrowedAt = l.BorrowedAt,
                DueAt = l.DueAt,
                ReturnedAt = l.ReturnedAt,
                Status = l.Status
            })
            .FirstOrDefaultAsync();
    }
}