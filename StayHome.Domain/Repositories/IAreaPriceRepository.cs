namespace Domain.Repositories;

public interface IAreaPriceRepository
{
    Task<double?> DeliveryCoast(Guid areaId1, Guid areaId2);
}