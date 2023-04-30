using Domain.Entities.Security;
using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<Guid>
{
    public Task<string> GetEmployeeAccessToken(Employee employee);

}