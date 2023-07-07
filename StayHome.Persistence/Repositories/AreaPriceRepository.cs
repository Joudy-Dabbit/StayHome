using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class AreaPriceRepository : StayHomeRepository, IAreaPriceRepository
{
    public AreaPriceRepository(StayHomeDbContext context) : base(context) { }
    
    public async Task<double?> DeliveryCoast(Guid areaId1, Guid areaId2)
    {
        return await _priceBetween(areaId1, areaId2);
    }


    #region - private -
    private async Task<double?> _priceBetween(Guid areaId1, Guid areaId2)
        => (await _priceBetween(areaId1, new List<Guid>() { areaId2 })).Values.FirstOrDefault();
    
    private async Task<Dictionary<Guid, double>> _priceBetween(Guid areaId1, List<Guid> areaId2)
        => await Context.AreaPrices.Where(ap => (!ap.UtcDateDeleted.HasValue)
                                                                   && ((ap.Area1Id == areaId1 && areaId2.Contains(ap.Area2Id)) || (areaId2.Contains(ap.Area1Id) && ap.Area2Id == areaId1)))
            .ToDictionaryAsync(ap => ap.Area1Id == areaId1 ? ap.Area2Id : ap.Area1Id, ap => ap.Price);
    #endregion
}