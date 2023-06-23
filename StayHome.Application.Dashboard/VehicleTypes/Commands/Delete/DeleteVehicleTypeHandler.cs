using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.VehicleTypes;

public class DeleteVehicleTypeHandler : IRequestHandler<DeleteVehicleTypeCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public DeleteVehicleTypeHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteVehicleTypeCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDelete = await _repository.TrackingQuery<VehicleType>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);
        _repository.SoftDelete(toDelete);
        return OperationResponse.WithOk();
    }
}