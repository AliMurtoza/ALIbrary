using ALIbrary.Application.BookCopies.DTOs;

namespace ALIbrary.Application.BookCopies.Interfaces;

public interface IBookCopyService
{
    Task<BookCopyResponse> CreateAsync(CreateBookCopyRequest request);

    Task<List<BookCopyResponse>> GetAllAsync();

    Task<BookCopyResponse?> GetByIdAsync(Guid id);

    Task<BookCopyResponse?> UpdateAsync(Guid id, UpdateBookCopyRequest request);

    Task<bool> DeleteAsync(Guid id);
}