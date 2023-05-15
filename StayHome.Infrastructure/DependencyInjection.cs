using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Dashboard.Core.Abstractions;
using StayHome.Application.Dashboard.Core.Abstractions.Http;
using StayHome.Infrastructure.Files;
using StayHome.Infrastructure.Http;
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
        services.AddScoped<IHttpService, HttpService>();

        return services;
    }
}