using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class DeleteOrderHandler: IRequestHandler<DeleteOrderCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public DeleteOrderHandler(
        IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteOrderCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var orders = await _repository.TrackingQuery<Order>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);

        _repository.SoftDelete(orders);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}