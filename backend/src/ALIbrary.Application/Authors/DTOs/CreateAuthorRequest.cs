namespace ALIbrary.Application.Authors.DTOs;

public class CreateAuthorRequest
{
    public string DisplayName { get; set; } = string.Empty;

    public string? Biography { get; set; }
}