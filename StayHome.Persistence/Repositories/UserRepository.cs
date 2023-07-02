using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.Dashboard.Core.Abstractions;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using EasyRefreshToken.Result;
using EasyRefreshToken.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Neptunee.BaseCleanArchitecture.OResponse;
using StayHome.Contracts.Security;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class UserRepository : StayHomeRepository, IUserRepository
{
    private readonly IJwtService _jwt;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenService<Guid> _tokenService;

    public UserRepository(StayHomeDbContext context ,IJwtService jwt,
        UserManager<User> userManager, IConfiguration configuration,
        ITokenService<Guid> tokenService) : base(context)
    {
        _jwt = jwt;
        _userManager = userManager;
        _configuration = configuration;
        _tokenService = tokenService;
    }

    public async Task<bool> IsEmailExist<TUser>(string email, Guid? id = null) where TUser : User
        =>  await Query<TUser>().AnyAsync(u => (!id.HasValue && u.Email == email) || 
                                               (id.HasValue && id.Value != u.Id && u.Email == email));

    public async Task<bool> ChangeBlockStatus<TUser>(Guid id) where TUser : User
    {
        var user = await TrackingQuery<TUser>().Where(e => e.Id == id).FirstAsync();
        if (!user.DateBlocked.HasValue)
        {
            user.DateBlocked = DateTimeOffset.Now;
            return true;
        }

        user.DateBlocked = null;
        return true;
    }

    public async Task<TokenResult> GenerateRefreshToken(Guid userId) => await _tokenService.OnLogin(userId);

    public async Task<IdentityResult> AddWithRole(User user, StayHomeRoles role, string? password = null)
    {
        IdentityResult identityResult;
        identityResult =  await _userManager.CreateAsync(user, password);
            if (!identityResult.Succeeded) 
                return identityResult;

            identityResult = await _userManager.AddToRoleAsync(user, role.ToString());
        return identityResult;
    }
  
    public string GenerateAccessToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName.ToString()),
            new Claim(ConstValues.AppClaims.Type, user.GetType().Name),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.UtcNow.AddDays(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public async Task<OperationResponse<TokenDto>> RefreshToken(string accessToken, string refreshToken)
    {
        var principal = GetPrincipalFromExpiredToken(accessToken);
        var username = principal.Identity.Name; //this is mapped to the Name claim by default

        var user = Context.Users.SingleOrDefault(u => u.UserName == username);
        if (user == null)
            return OperationResponse.With(HttpStatusCode.NotFound, "NotExist").ToResponse<TokenDto>();;

        var tokenResult = await _tokenService.OnAccessTokenExpired(user.Id, refreshToken);

        if (!tokenResult.IsSucceded)
            return OperationResponse.WithBadRequest(tokenResult.ErrorMessage).ToResponse<TokenDto>();

        var roles = await _userManager.GetRolesAsync(user);
        var newAccessToken = GenerateAccessToken(user, roles);

        await Context.SaveChangesAsync();
        return OperationResponse.WithOk().ToResponse(new TokenDto
        {
            AccessToken = newAccessToken,
            RefreshToken = tokenResult.Token,
        });
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
            ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        return principal;
    }

    public async Task TryModifyPassword(User user, string? newPassword)
    {
        if (newPassword.IsNullOrEmpty())
            return;
        
        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, newPassword);
    }
}