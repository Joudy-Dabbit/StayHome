using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Areas;

public class GetNamesAreasHandler : IRequestHandler<GetNamesAreasQuery.Request,
    OperationResponse<List<GetNamesAreasQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetNamesAreasHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetNamesAreasQuery.Response>>> HandleAsync(GetNamesAreasQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetNamesAreasQuery.Response.Selector());
}