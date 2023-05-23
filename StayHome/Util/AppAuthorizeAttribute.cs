using Domain.Enum;
using Microsoft.AspNetCore.Authorization;

namespace StayHome.Util;

public class AppAuthorizeAttribute : AuthorizeAttribute
{
    public AppAuthorizeAttribute(params StayHomeRoles[] roles)
    {
        Roles = string.Join(",", roles.Select(x => x.ToString()));
        AuthenticationSchemes = "Bearer"; 
    }
}