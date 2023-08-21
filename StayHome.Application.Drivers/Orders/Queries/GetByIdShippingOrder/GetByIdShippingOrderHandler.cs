using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdShippingOrderHandler: IRequestHandler<GetByIdShippingOrderQuery.Request,
    OperationResponse<GetByIdShippingOrderQuery.Response>>
{
    private readonly IOrderRepository _repository;

    public GetByIdShippingOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdShippingOrderQuery.Response>> HandleAsync(GetByIdShippingOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
    {
        var order = await _repository.Query<ShippingOrder>()
            .Include(o => o.Destination)
            .Include(o => o.Source)
            .Include(o => o.Shop)
            .FirstAsync(o => o.Id == request.Id, cancellationToken);
        var distance = await _repository.DistanceBetween(order.Destination.AreaId, order.Source!.AreaId);
        
        return await _repository.GetAsync(request.Id, GetByIdShippingOrderQuery.Response.Selector(distance));
    } 
}