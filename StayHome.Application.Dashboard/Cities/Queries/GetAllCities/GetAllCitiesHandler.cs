using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities;

public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery.Request,
    OperationResponse<List<GetAllCitiesQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllCitiesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllCitiesQuery.Response>>> HandleAsync(GetAllCitiesQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllCitiesQuery.Response.Selector());
}