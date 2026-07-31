namespace ALIbrary.Application.Authors.DTOs;

public class UpdateAuthorRequest
{
    public string DisplayName { get; set; } = string.Empty;

    public string? Biography { get; set; }
}