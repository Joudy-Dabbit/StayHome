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
    
    public ModifyShopHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdShopQuery.Response>> HandleAsync(ModifyShopCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var shop = await _repository.TrackingQuery<Shop>()
            .Where(s => s.Id == request.Id)
            .FirstAsync(cancellationToken);
        
        shop.Modify(request.Name,request.ImageUrl, request.CategoryId, request.AreaId);
        
        _repository.Update(shop);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(shop.Id, GetByIdShopQuery.Response.Selector);
    }
}