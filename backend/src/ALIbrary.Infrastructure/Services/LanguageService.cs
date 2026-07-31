using ALIbrary.Application.Languages.DTOs;
using ALIbrary.Application.Languages.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _context;

    public LanguageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LanguageResponse> CreateAsync(CreateLanguageRequest request)
    {
        var language = new Language
        {
            Name = request.Name,
            Code = request.Code
        };

        _context.Languages.Add(language);

        await _context.SaveChangesAsync();

        return new LanguageResponse
        {
            Id = language.Id,
            Name = language.Name,
            Code = language.Code
        };
    }

    public async Task<List<LanguageResponse>> GetAllAsync()
    {
        return await _context.Languages
            .Select(language => new LanguageResponse
            {
                Id = language.Id,
                Name = language.Name,
                Code = language.Code
            })
            .ToListAsync();
    }

    public async Task<LanguageResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Languages
            .Where(language => language.Id == id)
            .Select(language => new LanguageResponse
            {
                Id = language.Id,
                Name = language.Name,
                Code = language.Code
            })
            .FirstOrDefaultAsync();
    }

    public async Task<LanguageResponse?> UpdateAsync(Guid id, UpdateLanguageRequest request)
    {
        var language = await _context.Languages.FindAsync(id);

        if (language == null)
            return null;

        language.Name = request.Name;
        language.Code = request.Code;

        await _context.SaveChangesAsync();

        return new LanguageResponse
        {
            Id = language.Id,
            Name = language.Name,
            Code = language.Code
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var language = await _context.Languages.FindAsync(id);

        if (language == null)
            return false;

        _context.Languages.Remove(language);

        await _context.SaveChangesAsync();

        return true;
    }
}