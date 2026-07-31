using ALIbrary.Application.ReadingProgress.DTOs;

namespace ALIbrary.Application.ReadingProgress.Interfaces;

public interface IReadingProgressService
{
    Task<ReadingProgressResponse> CreateAsync(Guid userBookId);

    Task<ReadingProgressResponse?> UpdateAsync(
        Guid userBookId,
        UpdateReadingProgressRequest request);

    Task<ReadingProgressResponse?> GetAsync(Guid userBookId);
}