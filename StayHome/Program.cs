using Application.Dashboard.Core.Jwt;
using Domain;
using Domain.Entities;
using EasyRefreshToken.DependencyInjection;
using EasyRefreshToken.Models;
using Microsoft.OpenApi.Models;
using Neptunee.BaseCleanArchitecture.AppBuilder.InitialAppBuilder;
using Neptunee.BaseCleanArchitecture.DependencyInjection;
using Neptunee.BaseCleanArchitecture.SwaggerApi;
using StayHome.Persistence;
using StayHome;
using StayHome.Infrastructure;
using StayHome.Infrastructure.Jwt;
using StayHome.Persistence.Context;
using StayHome.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddSwaggerApi(o =>
    {
        o.AddBearerSecurityScheme();
        o.AddApiGroupDocs<ApiGroupNames>();
        o.SwaggerDoc("All", new OpenApiInfo()
        {
            Title = "All",
            Version = "v1"
        });
    })
    .AddExceptionHandlerFilter()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration, builder.Environment)
    .AddBaseCleanArchitecture(
        StayHome.Application.Dashboard.AssemblyReference.Assembly,
        StayHome.Application.Mobile.AssemblyReference.Assembly,
        StayHome.Persistence.AssemblyReference.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("Policy", policyBuilder =>
    {
        policyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowCredentials()
            .WithOrigins("https://localhost:4000")
            .SetIsOriginAllowed(_ => true);
    });
});

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddRefreshToken<StayHomeDbContext, RefreshToken<User, Guid>, User, Guid>
(op =>
    {
        op.TokenExpiredDays = ConstValues.ExpireRefreshTokenDay;
        op.MaxNumberOfActiveDevices = MaxNumberOfActiveDevices
            .Configure((typeof(Driver), 1), (typeof(Customer), 1), (typeof(Employee), 10));
    }
);

var app = builder.Build();

app.UseSwaggerApi(o => o.AddEndpoint("All")
    .AddEndpoints<ApiGroupNames>().SetDocExpansion());
app.UseCors("Policy");
app.UseAuthentication();
app.UseRouting();
app.MapControllers();

await app.MigrationAsync<StayHomeDbContext>(DataSeed.Seed);

app.Run();