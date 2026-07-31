namespace ALIbrary.Application.Publishers.DTOs;

public class UpdatePublisherRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}