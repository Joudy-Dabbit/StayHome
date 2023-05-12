using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;

namespace StayHome.Util;

public enum ApiGroupNames
{
    [OpenApiInfoGenerator(title: "Dash", version: "v1")] Dash,
    [OpenApiInfoGenerator(title: "Mobile", version: "v1")] Mobile,
}