using ALIbrary.Application.Languages.DTOs;

namespace ALIbrary.Application.Languages.Interfaces;

public interface ILanguageService
{
    Task<LanguageResponse> CreateAsync(CreateLanguageRequest request);

    Task<List<LanguageResponse>> GetAllAsync();

    Task<LanguageResponse?> GetByIdAsync(Guid id);

    Task<LanguageResponse?> UpdateAsync(Guid id, UpdateLanguageRequest request);

    Task<bool> DeleteAsync(Guid id);
}