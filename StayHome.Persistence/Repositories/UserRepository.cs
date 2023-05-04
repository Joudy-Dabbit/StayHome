using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dashboard.Core.Jwt;
using Domain;
using Domain.Entities;
using Domain.Entities.Security;
using Domain.Repositories;
using StayHome.Infrastructure.Jwt.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Presentation.Context;
using StayHome.Presentation.Repositories;

namespace StayHome.Presentation.Repositories;

public class UserRepository : StayHomeRepository, IUserRepository
{
    private readonly IJwtService _jwt;
    private readonly IUserRepository _userRepository;

    public UserRepository(StayHomeDbContext context, IJwtService jwt, IUserRepository userRepository) : base(context)
    {
        _jwt = jwt;
        _userRepository = userRepository;
    }

    // public async Task<string> GetEmployeeAccessToken(Employee employee)
    // {
    //     var claims = await _userRepository.GetAllClaimsAsync(employee.Id);
    //     AddUserTypeClaim(claims, ConstValues.UserType.Employee);
    //     return _jwt.GenerateJwtToken(claims);
    // }

    // public async Task<List<Claim>> GetAllClaimsAsync(Guid userId)
    // {
    //     var claims = await _userRepository.Query<User>().Where(u => u.Id == userId)
    //         .Select(u => new
    //         {
    //             Roles = u.UserRoles.Select(ur => new Claim(StayHomeClaimTypes.Role, ur.Role.Name)),
    //             UserClaims = u.UserClaims.Select(uc => uc.ToClaim())
    //         }).FirstAsync();
    //     
    //     return new List<Claim>
    //     {
    //         new(StayHomeClaimTypes.NameIdentifier, userId.ToString()),
    //         new(StayHomeClaimTypes.GenerateDate, DateTime.Now.ToLocalTime().ToString("G")),
    //     }.Union(claims.Roles).Union(claims.UserClaims).ToList();
    // }
    public static List<Claim> AddUserTypeClaim(List<Claim> claims, string userType)
    {
        claims.Add(new Claim("user-type", userType));
        return claims;
    }
}