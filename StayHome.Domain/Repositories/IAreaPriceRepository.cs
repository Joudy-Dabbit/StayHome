using Neptunee.BaseCleanArchitecture.Repository;

namespace Domain.Repositories;

public interface IAreaPriceRepository : IRepository<Guid>
{
    Task<double> DeliveryCoast(Guid areaId1, Guid areaId2);
    Task Add(Guid cityId,Guid areaId);
}