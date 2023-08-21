using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdDeliveryOrderHandler: IRequestHandler<GetByIdDeliveryOrderQuery.Request,
    OperationResponse<GetByIdDeliveryOrderQuery.Response>>
{
    private readonly IOrderRepository _repository;

    public GetByIdDeliveryOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdDeliveryOrderQuery.Response>> HandleAsync(GetByIdDeliveryOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
    {
        var order = await _repository.Query<DeliveryOrder>()
            .Include(o => o.Destination)
            .Include(o => o.Source)
            .Include(o => o.Shop)
            .FirstAsync(o => o.Id == request.Id, cancellationToken);
        var distance = await _repository.DistanceBetween(order.Destination.AreaId, 
            order.ShopId ?? order.Source!.AreaId);
        
        return await _repository.GetAsync(request.Id, GetByIdDeliveryOrderQuery.Response.Selector(distance));
    } 
}