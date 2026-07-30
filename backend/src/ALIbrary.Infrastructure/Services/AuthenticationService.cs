using ALIbrary.Application.Authentication.DTOs;
using ALIbrary.Application.Authentication.Interfaces;
using ALIbrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ALIbrary.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthenticationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationResponse> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}