using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;

namespace StayHome.Util;

public enum ApiGroupNames
{
    [OpenApiInfoGenerator(title: "Dashboard", version: "v1")] Dashboard,
    [OpenApiInfoGenerator(title: "Mobile", version: "v1")] Mobile,
    [OpenApiInfoGenerator(title: "Driver", version: "v1")] Driver,
}