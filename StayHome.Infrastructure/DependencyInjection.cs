using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StayHome.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // services.AddElMail(configuration);
        // services.AddElMailMultiOptions(configuration);
        // services.AddScoped<IEmailService, EmailService>();
        // services.AddScoped<IFileService, FileService>();
        // services.AddScoped<ISmsService, SmsService>();
        // services.AddScoped<IHttpService, HttpService>();
        // services.AddElMTN(configuration);
        // services.AddNominatim();
         return services;
    }
}