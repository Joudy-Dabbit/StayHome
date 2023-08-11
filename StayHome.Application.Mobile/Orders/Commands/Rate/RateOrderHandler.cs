using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Orders;

public class RateOrderHandler: IRequestHandler<RateOrderCommand.Request,
    OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public RateOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    } 
    public async Task<OperationResponse> HandleAsync(RateOrderCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var order = await _repository.TrackingQuery<Order>()
            .FirstAsync(o => o.Id == request.Id, cancellationToken);

        order.Rate(request.Star, request.Comment);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}