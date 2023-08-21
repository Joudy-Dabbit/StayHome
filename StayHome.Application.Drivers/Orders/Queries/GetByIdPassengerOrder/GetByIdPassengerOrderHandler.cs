using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdPassengerOrderHandler: IRequestHandler<GetByIdPassengerOrderQuery.Request,
    OperationResponse<GetByIdPassengerOrderQuery.Response>>
{
    private readonly IOrderRepository _repository;

    public GetByIdPassengerOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdPassengerOrderQuery.Response>> HandleAsync(GetByIdPassengerOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
    {
        var order = await _repository.Query<PassengerOrder>()
            .Include(o => o.Destination)
            .Include(o => o.Source)
            .FirstAsync(o => o.Id == request.Id, cancellationToken);
        var distance = await _repository.DistanceBetween(order.Destination.AreaId, order.Source!.AreaId);
        
        return await _repository.GetAsync(request.Id, GetByIdPassengerOrderQuery.Response.Selector(distance));
    } 
}