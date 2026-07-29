using Microsoft.Extensions.DependencyInjection;

namespace ALIbrary.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here

        return services;
    }
}