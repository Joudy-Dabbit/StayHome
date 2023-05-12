using Application.Dashboard.Core.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayHome.Application.Dashboard.Core.Files;
using StayHome.Infrastructure.Files;
using StayHome.Infrastructure.Jwt;

namespace StayHome.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddJwtSecurity(configuration);
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}