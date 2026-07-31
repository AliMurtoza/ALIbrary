using ALIbrary.Application.Publishers.DTOs;
using ALIbrary.Application.Publishers.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class PublisherService : IPublisherService
{
    private readonly ApplicationDbContext _context;

    public PublisherService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PublisherResponse> CreateAsync(CreatePublisherRequest request)
    {
        var publisher = new Publisher
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Publishers.Add(publisher);

        await _context.SaveChangesAsync();

        return new PublisherResponse
        {
            Id = publisher.Id,
            Name = publisher.Name,
            Description = publisher.Description
        };
    }

    public async Task<List<PublisherResponse>> GetAllAsync()
    {
        return await _context.Publishers
            .Select(publisher => new PublisherResponse
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Description = publisher.Description
            })
            .ToListAsync();
    }

    public async Task<PublisherResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Publishers
            .Where(publisher => publisher.Id == id)
            .Select(publisher => new PublisherResponse
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Description = publisher.Description
            })
            .FirstOrDefaultAsync();
    }

    public async Task<PublisherResponse?> UpdateAsync(Guid id, UpdatePublisherRequest request)
    {
        var publisher = await _context.Publishers.FindAsync(id);

        if (publisher == null)
            return null;

        publisher.Name = request.Name;
        publisher.Description = request.Description;

        await _context.SaveChangesAsync();

        return new PublisherResponse
        {
            Id = publisher.Id,
            Name = publisher.Name,
            Description = publisher.Description
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var publisher = await _context.Publishers.FindAsync(id);

        if (publisher == null)
            return false;

        _context.Publishers.Remove(publisher);

        await _context.SaveChangesAsync();

        return true;
    }
}