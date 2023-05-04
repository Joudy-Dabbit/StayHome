using System.Reflection.Metadata;
using Microsoft.OpenApi.Models;
using Neptunee.BaseCleanArchitecture.DependencyInjection;
using Neptunee.BaseCleanArchitecture.SwaggerApi;
using StayHome.Presentation;
using StayHome;
using StayHome.Infrastructure;
using StayHome.Presentation.Context;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


builder.Services
    .AddSwaggerApi(o =>
    {
        o.AddBearerSecurityScheme();
        o.AddApiGroupDocs<ApiGroupNames>();
        o.SwaggerDoc("All", new OpenApiInfo
        {
            Title = "All",
            Version = string.Empty,
        });
    })
    .AddExceptionHandlerFilter()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration,builder.Environment)
    .AddBaseCleanArchitecture(
        StayHome.Application.Dashboard.AssemblyReference.Assembly,
        StayHome.Application.Mobile.AssemblyReference.Assembly,
        StayHome.Presentation.AssemblyReference.Assembly);


app.Run();