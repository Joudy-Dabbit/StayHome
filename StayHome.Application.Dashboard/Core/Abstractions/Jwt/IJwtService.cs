using System.Security.Claims;

namespace Application.Dashboard.Core.Abstractions;

public interface IJwtService
{ 
    string GenerateJwtToken(IEnumerable<Claim> claims);
}