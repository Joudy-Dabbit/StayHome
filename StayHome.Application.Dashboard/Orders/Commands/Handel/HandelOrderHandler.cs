using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;
using StayHome.Application.Dashboard.Drivers;

namespace StayHome.Application.Dashboard.Orders;

public class HandelOrderHandler: IRequestHandler<HandelOrderCommand.Request,
    OperationResponse<GetByIdShippingOrderQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IHttpService _httpService;

    public HandelOrderHandler(IStayHomeRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    } 
    public async Task<OperationResponse<GetByIdShippingOrderQuery.Response>> HandleAsync(HandelOrderCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var order = await _repository.TrackingQuery<Order>()
            .FirstAsync(o => o.Id == request.Id, cancellationToken);

        order.Handle(request.DriverId,_httpService.CurrentUserId!.Value);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(order.Id, GetByIdShippingOrderQuery.Response.Selector);    
    }
}