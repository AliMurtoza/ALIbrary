using ALIbrary.Application.Authentication.DTOs;
using ALIbrary.Application.Authentication.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ALIbrary.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager, 
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new Exception("Email already exists.");
        }

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
        }

        var member = new Member
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserId = user.Id
        };

        _context.Members.Add(member);

        await _context.SaveChangesAsync();

        return new AuthenticationResponse
        {
            Token = "",
            ExpiresAt = DateTime.UtcNow
        };
    }

    public Task<AuthenticationResponse> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}