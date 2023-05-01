using System.Security.Claims;

namespace Application.Dashboard.Core.Jwt;

public interface IJwtService
{ 
    string GenerateJwtToken(IEnumerable<Claim> claims);
}