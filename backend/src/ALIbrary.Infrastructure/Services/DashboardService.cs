using ALIbrary.Application.Books.DTOs;
using ALIbrary.Application.Dashboard.DTOs;
using ALIbrary.Application.Dashboard.Interfaces;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class DashboardService : IDashboardService
{
    private readonly ApplicationDbContext _context;

    public DashboardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardResponse> GetDashboardAsync()
    {
        return new DashboardResponse
        {
            TotalBooks = await _context.Books.CountAsync(),

            TotalAuthors = await _context.Authors.CountAsync(),

            ActiveLoans = await _context.Loans.CountAsync(),

            PendingReservations = await _context.Reservations.CountAsync(),

            RecentBooks = await _context.Books
                .OrderByDescending(b => b.CreatedAt)
                .Take(5)
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublishedYear = b.PublicationYear,
                    Description = b.Description ?? "",

                    CategoryId = b.CategoryId,
                    CategoryName = b.Category.Name,

                    PublisherId = b.PublisherId,
                    PublisherName = b.Publisher.Name,

                    LanguageId = b.LanguageId,
                    LanguageName = b.Language.Name
                })
                .ToListAsync()
        };
    }
}