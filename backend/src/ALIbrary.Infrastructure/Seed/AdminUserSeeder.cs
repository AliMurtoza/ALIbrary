using ALIbrary.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ALIbrary.Infrastructure.Seed;

public static class AdminUserSeeder
{
    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager)
    {
        const string email = "admin@alibrary.local";
        const string password = "Admin123!";

        var admin = await userManager.FindByEmailAsync(email);

        if (admin != null)
            return;

        admin = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result =
            await userManager.CreateAsync(admin, password);

        if (!result.Succeeded)
            throw new Exception("Failed to create default admin user.");

        await userManager.AddToRoleAsync(admin, "Admin");
    }
}