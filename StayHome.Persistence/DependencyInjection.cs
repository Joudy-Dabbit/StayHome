using Domain.Entities;
using Domain.Interfaces.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StayHome.Presentation.Context;

namespace StayHome.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment)
    {

        services.AddDbContext<IStayHomeDbContext, StayHomeDbContext>(o =>
               {
                   o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                   if (!environment.IsProduction())
                   {
                       o.EnableSensitiveDataLogging();
                   }
               })
               .AddIdentity<User, IdentityRole<Guid>>(options =>
               {
                   options.Password.RequiredLength = 4;
                   options.Password.RequiredUniqueChars = 0;
                   options.Password.RequireDigit = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireLowercase = false;
               })
               .AddEntityFrameworkStores<StayHomeDbContext>()
               .AddDefaultTokenProviders();
           return services;
        }
}