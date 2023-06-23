using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class ModifyVehicleHandler : IRequestHandler<ModifyVehicleCommand.Request,
    OperationResponse<GetByIdVehicleQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public ModifyVehicleHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResponse<GetByIdVehicleQuery.Response>> HandleAsync(ModifyVehicleCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var vehicle = await _repository.TrackingQuery<Vehicle>()
            .Where(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        vehicle.Modify(request.Name, request.VehicleTypeId, request.MaxCapacity,
            request.Color, request.Number);
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(vehicle.Id, GetByIdVehicleQuery.Response.Selector);
    }
}