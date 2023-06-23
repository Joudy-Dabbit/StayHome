using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class GetByIdVehiclesHandler : IRequestHandler<GetByIdVehicleQuery.Request,
    OperationResponse<GetByIdVehicleQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdVehiclesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdVehicleQuery.Response>> HandleAsync(GetByIdVehicleQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(request.Id, GetByIdVehicleQuery.Response.Selector);
}