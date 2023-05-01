using System.Security.Claims;
using Domain.Entities.Security;
using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<Guid>
{
   // public Task<string> GetEmployeeAccessToken(Employee employee);
   // public Task<List<Claim>> GetAllClaimsAsync(Guid userId);
}