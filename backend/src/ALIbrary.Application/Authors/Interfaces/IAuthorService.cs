using ALIbrary.Application.Authors.DTOs;

namespace ALIbrary.Application.Authors.Interfaces;

public interface IAuthorService
{
    Task<AuthorResponse> CreateAsync(CreateAuthorRequest request);

    Task<List<AuthorResponse>> GetAllAsync();

    Task<AuthorResponse?> GetByIdAsync(Guid id);

    Task<AuthorResponse?> UpdateAsync(Guid id, UpdateAuthorRequest request);

    Task<bool> DeleteAsync(Guid id);
}