using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Settings;

public class GetAllAreasHandler : IRequestHandler<GetAllAreasQuery.Request,
    OperationResponse<List<GetAllAreasQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IHttpService _httpService;

    public GetAllAreasHandler(IStayHomeRepository repository,
        IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<List<GetAllAreasQuery.Response>>> HandleAsync(GetAllAreasQuery.Request request,
        CancellationToken cancellationToken = new())
    {
        var user = await _repository.Query<Customer>()
            .FirstAsync(c => c.Id == _httpService.CurrentUserId!.Value, cancellationToken);
        return await _repository.GetAsync(a => a.CityId == user.CityId,
                                             GetAllAreasQuery.Response.Selector());
    }
}