using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class ModifyShopHandler : IRequestHandler<ModifyShopCommand.Request,
    OperationResponse<GetByIdShopQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;
    
    public ModifyShopHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResponse<GetByIdShopQuery.Response>> HandleAsync(ModifyShopCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var shop = await _repository.TrackingQuery<Shop>()
            .Where(s => s.Id == request.Id)
            .Include(s => s.WorkTimes)
            .FirstAsync(cancellationToken);
        var imag = await _fileService.Modify(shop.ImageUrl, request.ImageFile);
        
        shop.Modify(request.Name,imag, request.CategoryId, request.AreaId);
        
        if(request.WorkTimes != null)
        {
            shop.ClearWorkTime();
            request.WorkTimes.ForEach(w => { shop.AddWorkTime(w.DayOfWeek, w.StartTime, w.EndTime); });
        }
        
        _repository.Update(shop);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(shop.Id, GetByIdShopQuery.Response.Selector);
    }
}