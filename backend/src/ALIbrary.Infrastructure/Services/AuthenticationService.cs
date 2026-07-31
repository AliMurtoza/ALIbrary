using ALIbrary.Application.Authentication.DTOs;
using ALIbrary.Application.Authentication.Interfaces;
using ALIbrary.Domain.Entities;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Exceptions;
using ALIbrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ALIbrary.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager, 
        ApplicationDbContext context,
        IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _context = context;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new BadRequestException("User already exists.");
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

        await _userManager.AddToRoleAsync(user, "Member");

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

    public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new BadRequestException("Invalid email or password.");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            throw new BadRequestException("Invalid email or password.");
        }

        var token = _jwtTokenService.GenerateToken(
            user.Id,
            user.Email!);

        return new AuthenticationResponse
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddHours(1)
        };
    }
}