using System.Reflection.Metadata;
using Domain;
using Domain.Entities;
using EasyRefreshToken.DependencyInjection;
using EasyRefreshToken.Models;
using Microsoft.OpenApi.Models;
using Neptunee.BaseCleanArchitecture.DependencyInjection;
using Neptunee.BaseCleanArchitecture.SwaggerApi;
using StayHome.Presentation;
using StayHome;
using StayHome.Infrastructure;
using StayHome.Presentation.Context;

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
    .AddPersistence(builder.Configuration,builder.Environment)
    .AddBaseCleanArchitecture(
        StayHome.Application.Dashboard.AssemblyReference.Assembly,
        StayHome.Application.Mobile.AssemblyReference.Assembly,
        StayHome.Presentation.AssemblyReference.Assembly);

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

builder.Services.AddRefreshToken<StayHomeDbContext, RefreshToken<User, Guid>, User, Guid>
(op =>
    {
        op.TokenExpiredDays = ConstValues.ExpireRefreshTokenDay;

        op.PreventingLoginWhenAccessToMaxNumberOfActiveDevices = false;
    }
);

var app = builder.Build();

app.UseSwaggerApi(o => o.AddEndpoint("All")
    .AddEndpoints<ApiGroupNames>().SetDocExpansion());
app.UseCors("Policy");
app.UseAuthentication();
app.UseRouting();
app.MapControllers();
app.Run();