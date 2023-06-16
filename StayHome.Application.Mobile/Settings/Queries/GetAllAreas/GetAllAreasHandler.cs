using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Settings;

public class GetAllAreasHandler : IRequestHandler<GetAllAreasQuery.Request,
    OperationResponse<List<GetAllAreasQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllAreasHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllAreasQuery.Response>>> HandleAsync(GetAllAreasQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllAreasQuery.Response.Selector());
}