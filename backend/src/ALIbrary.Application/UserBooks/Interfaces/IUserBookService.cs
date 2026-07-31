using ALIbrary.Application.UserBooks.DTOs;

namespace ALIbrary.Application.UserBooks.Interfaces;

public interface IUserBookService
{
    Task<UserBookResponse> CreateAsync(CreateUserBookRequest request);

    Task<UserBookResponse?> UpdateAsync(Guid id, UpdateUserBookRequest request);

    Task<List<UserBookResponse>> GetAllAsync();

    Task<UserBookResponse?> GetByIdAsync(Guid id);
}