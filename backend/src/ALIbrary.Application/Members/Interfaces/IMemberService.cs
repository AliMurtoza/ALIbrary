using ALIbrary.Application.Members.DTOs;

namespace ALIbrary.Application.Members.Interfaces;

public interface IMemberService
{
    Task<MemberResponse> CreateAsync(CreateMemberRequest request);

    Task<List<MemberResponse>> GetAllAsync();

    Task<MemberResponse?> GetByIdAsync(Guid id);

    Task<MemberResponse?> UpdateAsync(Guid id, UpdateMemberRequest request);

    Task<bool> DeleteAsync(Guid id);
}