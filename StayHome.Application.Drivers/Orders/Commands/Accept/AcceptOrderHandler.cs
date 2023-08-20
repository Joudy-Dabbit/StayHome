using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class AcceptOrderHandler: IRequestHandler<AcceptOrderCommand.Request,
    OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public AcceptOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(AcceptOrderCommand.Request request,
        CancellationToken cancellationToken = new())
    {
      var  order = await _repository.TrackingQuery<Order>()
          .Where(o => o.Id == request.Id).FirstAsync(cancellationToken);
      
      order.AddStage(OrderStages.OnWay);
      await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
      
      return OperationResponse.WithOk();
    }
}