using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.VehicleTypes;

public class GetAllVehicleTypesHandler : IRequestHandler<GetAllVehicleTypesQuery.Request,
    OperationResponse<List<GetAllVehicleTypesQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllVehicleTypesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllVehicleTypesQuery.Response>>> HandleAsync(GetAllVehicleTypesQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllVehicleTypesQuery.Response.Selector());
}