namespace ALIbrary.Application.Authentication.DTOs;

public class AuthenticationResponse
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
}