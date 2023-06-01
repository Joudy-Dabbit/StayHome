using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities;

public class GetAllCitiesWithAreasHandler : IRequestHandler<GetAllCitiesWithAreasQuery.Request,
OperationResponse<List<GetAllCitiesWithAreasQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllCitiesWithAreasHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllCitiesWithAreasQuery.Response>>> HandleAsync(GetAllCitiesWithAreasQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllCitiesWithAreasQuery.Response.Selector());
}