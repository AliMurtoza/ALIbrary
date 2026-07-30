using ALIbrary.Application.Authentication.DTOs;

namespace ALIbrary.Application.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);

    Task<AuthenticationResponse> LoginAsync(LoginRequest request);
}