using ALIbrary.Application.Books.DTOs;

namespace ALIbrary.Application.Books.Interfaces;

public interface IBookService
{
    Task<BookResponse> CreateAsync(CreateBookRequest request);

    Task<List<BookResponse>> GetAllAsync();

    Task<BookResponse?> GetByIdAsync(Guid id);

    Task<BookResponse?> UpdateAsync(Guid id, UpdateBookRequest request);

    Task<bool> DeleteAsync(Guid id);
}