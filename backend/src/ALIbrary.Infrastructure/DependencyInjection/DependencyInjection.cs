using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ALIbrary.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register infrastructure services here

        return services;
    }
}