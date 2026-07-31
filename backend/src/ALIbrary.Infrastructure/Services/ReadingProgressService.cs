using ALIbrary.Application.ReadingProgress.DTOs;
using ALIbrary.Application.ReadingProgress.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class ReadingProgressService : IReadingProgressService
{
    private readonly ApplicationDbContext _context;

    public ReadingProgressService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ReadingProgressResponse> CreateAsync(Guid userBookId)
    {
        var userBook = await _context.UserBooks.FindAsync(userBookId);

        if (userBook == null)
            throw new NotFoundException("UserBook not found.");

        var exists = await _context.ReadingProgress
            .AnyAsync(r => r.UserBookId == userBookId);

        if (exists)
            throw new BadRequestException("Reading progress already exists.");

        var progress = new Domain.Entities.ReadingProgress
        {
            UserBookId = userBookId,
            CurrentPage = 0,
            LastUpdatedAt = DateTime.UtcNow
        };

        _context.ReadingProgress.Add(progress);

        await _context.SaveChangesAsync();

        return new ReadingProgressResponse
        {
            Id = progress.Id,
            UserBookId = progress.UserBookId,
            CurrentPage = progress.CurrentPage,
            StartedReadingAt = progress.StartedReadingAt,
            FinishedReadingAt = progress.FinishedReadingAt,
            LastUpdatedAt = progress.LastUpdatedAt
        };
    }

    public async Task<ReadingProgressResponse?> UpdateAsync(
        Guid userBookId,
        UpdateReadingProgressRequest request)
    {
        var progress = await _context.ReadingProgress
            .FirstOrDefaultAsync(r => r.UserBookId == userBookId);

        if (progress == null)
            return null;

        progress.CurrentPage = request.CurrentPage;
        progress.StartedReadingAt = request.StartedReadingAt;
        progress.FinishedReadingAt = request.FinishedReadingAt;
        progress.LastUpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return new ReadingProgressResponse
        {
            Id = progress.Id,
            UserBookId = progress.UserBookId,
            CurrentPage = progress.CurrentPage,
            StartedReadingAt = progress.StartedReadingAt,
            FinishedReadingAt = progress.FinishedReadingAt,
            LastUpdatedAt = progress.LastUpdatedAt
        };
    }

    public async Task<ReadingProgressResponse?> GetAsync(Guid userBookId)
    {
        return await _context.ReadingProgress
            .Where(r => r.UserBookId == userBookId)
            .Select(r => new ReadingProgressResponse
            {
                Id = r.Id,
                UserBookId = r.UserBookId,
                CurrentPage = r.CurrentPage,
                StartedReadingAt = r.StartedReadingAt,
                FinishedReadingAt = r.FinishedReadingAt,
                LastUpdatedAt = r.LastUpdatedAt
            })
            .FirstOrDefaultAsync();
    }
}