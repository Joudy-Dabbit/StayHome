using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class DeleteRepository : Repository<Guid, StayHomeDbContext>, IDeleteRepository
{
    private readonly IFileService _fileService;

    public DeleteRepository(StayHomeDbContext context, IFileService fileService) : base(context)
    {
        _fileService = fileService;
    }

    public async Task DeleteCity(List<Guid> ids)
    {
        var cities = await TrackingQuery<City>()
            .Include("Areas.AreaPrices2")
            .Include("Areas.AreaPrices1")
            .Where(c => ids.Contains(c.Id)).ToListAsync();

        _deleteCity(cities);
        await UnitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteShops(List<Guid> ids)
    {
        var shops = await TrackingQuery<Shop>()
            .Include(b => b.Products.Where(lb => !lb.UtcDateDeleted.HasValue))
            .Include(b => b.WorkTimes.Where(lb => !lb.UtcDateDeleted.HasValue))
            .Where(b => ids.Contains(b.Id)).ToListAsync();

        _deleteShops(shops);
        await UnitOfWork.SaveChangesAsync();
    }
    public async Task DeleteProducts(List<Guid> ids)
    {
        var products = await TrackingQuery<Product>()
            .Where(p => ids.Contains(p.Id)).ToListAsync();

        _deleteProducts(products);
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
    private void _deleteAreaPrices(List<AreaPrice> areaPrices) => SoftDelete(areaPrices);
    private void _deleteShops(List<Shop> shops)
    {
        var products = shops.SelectMany(b => b.Products).ToList();
        var workTimes = shops.SelectMany(b => b.WorkTimes).ToList();
        var images = shops.Select(b => b.ImageUrl).ToList();

        _fileService.Delete(images);
        _deleteProducts(products);
        _deleteWorkTimes(workTimes);
        SoftDelete(shops);
    }
    private void _deleteProducts(List<Product> products)
    {
        var images = products.Select(b => b.ImageUrl).ToList();

        _fileService.Delete(images);
        SoftDelete(products);
    }
    private void _deleteWorkTimes(List<WorkTime> workTimes) => SoftDelete(workTimes);
    #endregion
}