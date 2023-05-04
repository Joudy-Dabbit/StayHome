using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;

namespace StayHome;

public enum ApiGroupNames
{
    [OpenApiInfoGenerator(title: "Dash", version: "v1")] Dash,
    [OpenApiInfoGenerator(title: "Mobile", version: "v2")] Mobile,
    [OpenApiInfoGenerator(title: "All", version: "v2")] All,
}