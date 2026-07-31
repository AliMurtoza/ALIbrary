namespace ALIbrary.Application.Publishers.DTOs;

public class CreatePublisherRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}