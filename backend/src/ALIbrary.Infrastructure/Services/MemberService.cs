using ALIbrary.Application.Members.DTOs;
using ALIbrary.Application.Members.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ALIbrary.Infrastructure.Services;

public class MemberService : IMemberService
{
    private readonly ApplicationDbContext _context;

    public MemberService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MemberResponse> CreateAsync(CreateMemberRequest request)
    {
        var member = new Member
        {
            UserId = request.UserId,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        _context.Members.Add(member);

        await _context.SaveChangesAsync();

        return new MemberResponse
        {
            Id = member.Id,
            UserId = member.UserId,
            FirstName = member.FirstName,
            LastName = member.LastName
        };
    }

    public async Task<List<MemberResponse>> GetAllAsync()
    {
        return await _context.Members
            .Select(m => new MemberResponse
            {
                Id = m.Id,
                UserId = m.UserId,
                FirstName = m.FirstName,
                LastName = m.LastName
            })
            .ToListAsync();
    }

    public async Task<MemberResponse?> GetByIdAsync(Guid id)
    {
        return await _context.Members
            .Where(m => m.Id == id)
            .Select(m => new MemberResponse
            {
                Id = m.Id,
                UserId = m.UserId,
                FirstName = m.FirstName,
                LastName = m.LastName
            })
            .FirstOrDefaultAsync();
    }

    public async Task<MemberResponse?> UpdateAsync(Guid id, UpdateMemberRequest request)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            return null;

        member.UserId = request.UserId;
        member.FirstName = request.FirstName;
        member.LastName = request.LastName;

        await _context.SaveChangesAsync();

        return new MemberResponse
        {
            Id = member.Id,
            UserId = member.UserId,
            FirstName = member.FirstName,
            LastName = member.LastName
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var member = await _context.Members.FindAsync(id);

        if (member == null)
            return false;

        _context.Members.Remove(member);

        await _context.SaveChangesAsync();

        return true;
    }
}