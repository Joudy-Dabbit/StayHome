using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dashboard.Core.Jwt;
using Infrastructure.Jwt.Option;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Jwt;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtBearer;
        
    public JwtService(IOptions<JwtOptions> options = null)
    {
        _jwtBearer = options?.Value ?? new JwtOptions();
    }


    public string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearer.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(_jwtBearer.Issuer,
            _jwtBearer.Audience,
            claims,
            expires: DateTime.Now.Add(_jwtBearer.Expire),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}