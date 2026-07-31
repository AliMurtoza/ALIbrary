using ALIbrary.Application.Bookshelves.DTOs;

namespace ALIbrary.Application.Bookshelves.Interfaces;

public interface IBookshelfService
{
    Task<BookshelfResponse> CreateAsync(CreateBookshelfRequest request);

    Task<BookshelfResponse?> UpdateAsync(
        Guid id,
        UpdateBookshelfRequest request);

    Task<List<BookshelfResponse>> GetAllAsync();

    Task<BookshelfResponse?> GetByIdAsync(Guid id);

    Task<bool> DeleteAsync(Guid id);
}