using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IDeleteRepository : IRepository<Guid>
{
    Task DeleteCity(List<Guid> ids);
    Task DeleteShops(List<Guid> ids);
}