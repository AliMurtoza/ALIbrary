using ALIbrary.Application.Categories.DTOs;

namespace ALIbrary.Application.Categories.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request);

    Task<List<CategoryResponse>> GetAllAsync();

    Task<CategoryResponse?> GetByIdAsync(Guid id);

    Task<CategoryResponse?> UpdateAsync(Guid id, UpdateCategoryRequest request);

    Task<bool> DeleteAsync(Guid id);
}