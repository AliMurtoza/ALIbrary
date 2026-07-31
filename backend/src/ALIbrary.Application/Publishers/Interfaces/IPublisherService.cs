using ALIbrary.Application.Publishers.DTOs;

namespace ALIbrary.Application.Publishers.Interfaces;

public interface IPublisherService
{
    Task<PublisherResponse> CreateAsync(CreatePublisherRequest request);

    Task<List<PublisherResponse>> GetAllAsync();

    Task<PublisherResponse?> GetByIdAsync(Guid id);

    Task<PublisherResponse?> UpdateAsync(Guid id, UpdatePublisherRequest request);

    Task<bool> DeleteAsync(Guid id);
}