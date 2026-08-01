using ALIbrary.Application.Authentication.Interfaces;
using ALIbrary.Application.Authors.Interfaces;
using ALIbrary.Application.BookCopies.Interfaces;
using ALIbrary.Application.BookReviews.Interfaces;
using ALIbrary.Application.Books.Interfaces;
using ALIbrary.Application.Bookshelves.Interfaces;
using ALIbrary.Application.Categories.Interfaces;
using ALIbrary.Application.Dashboard.Interfaces;
using ALIbrary.Application.Languages.Interfaces;
using ALIbrary.Application.Loans.Interfaces;
using ALIbrary.Application.Members.Interfaces;
using ALIbrary.Application.Publishers.Interfaces;
using ALIbrary.Application.ReadingProgress.Interfaces;
using ALIbrary.Application.Reservations.Interfaces;
using ALIbrary.Application.UserBooks.Interfaces;
using ALIbrary.Infrastructure.Data;
using ALIbrary.Infrastructure.Identity;
using ALIbrary.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddScoped<IUserBookService, UserBookService>();
        services.AddScoped<IReadingProgressService, ReadingProgressService>();
        services.AddScoped<IBookReviewService, BookReviewService>();
        services.AddScoped<IBookshelfService, BookshelfService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IMemberService, MemberService>();

        return services;
    }
}