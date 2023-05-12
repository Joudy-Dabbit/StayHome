using Domain.Enum;
using Microsoft.AspNetCore.Authorization;

namespace StayHome.Util;

public class AppAuthorizeAttribute : AuthorizeAttribute
{
    public AppAuthorizeAttribute(params StayHomeRoles[] roles)
    {
        Roles = String.Join(",", roles);
    }
}