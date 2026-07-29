using Microsoft.Extensions.DependencyInjection;

namespace ALIbrary.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Register API services here

        return services;
    }
}