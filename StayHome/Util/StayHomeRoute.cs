using Microsoft.AspNetCore.Mvc;

namespace StayHome.Util;

public class StayHomeRoute : RouteAttribute
{
    public StayHomeRoute(ApiGroupNames name) : base($"api/{name}/[controller]/[action]")
    {
    }
} 