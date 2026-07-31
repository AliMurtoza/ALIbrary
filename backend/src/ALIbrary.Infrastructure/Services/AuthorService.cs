using ALIbrary.Application.Authors.DTOs;
using ALIbrary.Application.Authors.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly ApplicationDbContext _context;

    public AuthorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AuthorResponse> CreateAsync(CreateAuthorRequest request)
    {
        var author = new Author
        {
            DisplayName = request.DisplayName,
            Biography = request.Biography
        };

        _context.Authors.Add(author);

        await _context.SaveChangesAsync();

        return new AuthorResponse
        {
            Id = author.Id,
            DisplayName = author.DisplayName,
            Biography = author.Biography
        };
    }

    public async Task<List<AuthorResponse>> GetAllAsync()
    {
        return await _context.Authors
            .Select(author => new AuthorResponse
            {
                Id = author.Id,
                DisplayName = author.DisplayName,
                Biography = author.Biography
            })
            .ToListAsync();
    }

    public async Task<AuthorResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Authors
            .Where(author => author.Id == id)
            .Select(author => new AuthorResponse
            {
                Id = author.Id,
                DisplayName = author.DisplayName,
                Biography = author.Biography
            })
            .FirstOrDefaultAsync();
    }

    public async Task<AuthorResponse?> UpdateAsync(Guid id, UpdateAuthorRequest request)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
            return null;

        author.DisplayName = request.DisplayName;
        author.Biography = request.Biography;

        await _context.SaveChangesAsync();

        return new AuthorResponse
        {
            Id = author.Id,
            DisplayName = author.DisplayName,
            Biography = author.Biography
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);

        if (author == null)
            return false;

        _context.Authors.Remove(author);

        await _context.SaveChangesAsync();

        return true;
    }
}