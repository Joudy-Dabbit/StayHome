using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.VehicleTypes;

namespace StayHome.Application.Dashboard.Vehicles;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery.Request,
    OperationResponse<List<GetAllVehiclesQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllVehiclesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllVehiclesQuery.Response>>> HandleAsync(GetAllVehiclesQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllVehiclesQuery.Response.Selector);
}