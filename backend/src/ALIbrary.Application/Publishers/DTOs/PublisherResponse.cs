namespace ALIbrary.Application.Publishers.DTOs;

public class PublisherResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}