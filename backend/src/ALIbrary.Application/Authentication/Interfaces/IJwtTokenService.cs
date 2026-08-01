namespace ALIbrary.Application.Authentication.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(
        string userId,
        string email,
        IList<string> roles);
}