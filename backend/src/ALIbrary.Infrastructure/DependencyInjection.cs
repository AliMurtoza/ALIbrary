using ALIbrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ALIbrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using ALIbrary.Application.Authentication.Interfaces;
using ALIbrary.Infrastructure.Services;
using ALIbrary.Application.Books.Interfaces;
using ALIbrary.Application.Authors.Interfaces;
using ALIbrary.Application.Publishers.Interfaces;
using ALIbrary.Application.Categories.Interfaces;
using ALIbrary.Application.Languages.Interfaces;
using ALIbrary.Application.BookCopies.Interfaces;
using ALIbrary.Application.Loans.Interfaces;
using ALIbrary.Application.Reservations.Interfaces;

namespace ALIbrary.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IBookCopyService, BookCopyService>();
        services.AddScoped<ILoanService, LoanService>();
        services.AddScoped<IReservationService, ReservationService>();

        return services;
    }
}