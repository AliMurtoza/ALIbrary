namespace ALIbrary.Application.Authors.DTOs;

public class AuthorResponse
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string? Biography { get; set; }
}