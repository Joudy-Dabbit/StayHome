using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayHome.Infrastructure.Jwt;

namespace StayHome.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddJwtSecurity(configuration);

        return services;
    }
}