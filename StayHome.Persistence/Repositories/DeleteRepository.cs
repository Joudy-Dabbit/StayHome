using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class DeleteRepository : Repository<Guid, StayHomeDbContext>, IDeleteRepository
{
    public DeleteRepository(StayHomeDbContext context) : base(context) { }

    public async Task DeleteCity(List<Guid> ids)
    {
        var cities = await TrackingQuery<City>()
            .Include("Areas.AreaPrices2")
            .Include("Areas.AreaPrices1")
            .Where(c => ids.Contains(c.Id)).ToListAsync();

        _deleteCity(cities);
        await UnitOfWork.SaveChangesAsync();
    }


    #region - private -
    private void _deleteCity(List<City> cities)
    {
        var areas = cities.SelectMany(c => c.Areas).ToList();
        _deleteAreas(areas);

        SoftDelete(cities);
    }
    
    private void _deleteAreas(List<Area> areas)
    {
        var areaPrices = areas.SelectMany(a => a.AreaPrices1).ToList();
        areaPrices.AddRange(areas.SelectMany(a => a.AreaPrices2));

        _deleteAreaPrices(areaPrices);
        SoftDelete(areas);
    }
    private void _deleteAreaPrices(List<AreaPrice> areaPrices)
        => SoftDelete(areaPrices);
    #endregion
}