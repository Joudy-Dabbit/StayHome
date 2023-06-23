using Domain.Entities;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class AddVehicleHandler : IRequestHandler<AddVehicleCommand.Request,
    OperationResponse<GetAllVehiclesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public AddVehicleHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResponse<GetAllVehiclesQuery.Response>> HandleAsync(AddVehicleCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var vehicle = new Vehicle(request.Name,
            request.VehicleTypeId, request.MaxCapacity,
            request.Color, request.Number);
        
        _repository.Add(vehicle);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(vehicle.Id, GetAllVehiclesQuery.Response.Selector);
    }
}