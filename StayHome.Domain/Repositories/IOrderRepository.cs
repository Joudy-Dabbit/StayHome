using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IOrderRepository : IRepository<Guid>
{
    Task<double> DeliveryCoast(Guid areaId1, Guid areaId2);
    Task<int> DistanceBetween(Guid areaId1, Guid areaId2);
    Task<double> TotalProductPrice(List<Guid> productIds);
    Task Add(Guid areaId);
}