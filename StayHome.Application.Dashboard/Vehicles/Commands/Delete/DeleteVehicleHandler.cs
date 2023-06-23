using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand.Request, OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public DeleteVehicleHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteVehicleCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var toDelete = await _repository.TrackingQuery<Vehicle>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);
        _repository.SoftDelete(toDelete);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}