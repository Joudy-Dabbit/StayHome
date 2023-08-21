using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers.Orders;

public class AcceptOrderHandler: IRequestHandler<AcceptOrderCommand.Request,
    OperationResponse>
{
    private readonly IStayHomeRepository _repository;
    private readonly IHttpService _httpService;

    public AcceptOrderHandler(IStayHomeRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse> HandleAsync(AcceptOrderCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        if(_repository.Query<Order>()
               .Where(o => o.DriverId == _httpService.CurrentUserId!.Value)
               .Any(o => o.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage == OrderStages.OnWay))
            return OperationResponse.WithBadRequest("You already have an order being delivered");
        
        var  order = await _repository.TrackingQuery<Order>()
          .Where(o => o.Id == request.Id).FirstAsync(cancellationToken);
      
        order.AddStage(OrderStages.OnWay);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResponse.WithOk();
    }
}