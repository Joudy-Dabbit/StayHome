using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using StayHome.Application.Dashboard.Core.Abstractions.Http;
using StayHome.Application.Dashboard.Core.ExtensionMethods;

namespace StayHome.Infrastructure.Http;

public class HttpService : IHttpService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? CurrentUserId => _httpContextAccessor.HttpContext?.User?
        .FindFirst(ClaimTypes.NameIdentifier)?.Value?.StringToGuid();
}