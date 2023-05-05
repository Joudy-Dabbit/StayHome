using System.Security.Claims;
using Domain.Entities;
using Domain.Entities.Security;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<Guid>
{
   // public Task<string> GetEmployeeAccessToken(Employee employee);
   // public Task<List<Claim>> GetAllClaimsAsync(Guid userId);

   string GenerateAccessToken(User user, IList<string> roles, DateTime expierDate);
   Task<IdentityResult> AddWithRole(User user, StayHomeRoles role, string password);
}