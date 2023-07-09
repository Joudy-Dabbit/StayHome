using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Home;

public class GetHomeHandler : IRequestHandler<GetHomeQuery.Request,
    OperationResponse<List<GetHomeQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IHttpService _httpService;

    public GetHomeHandler(IStayHomeRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<List<GetHomeQuery.Response>>> HandleAsync(GetHomeQuery.Request request,
        CancellationToken cancellationToken = new())
    {
        var user = await _repository.Query<Customer>()
            .Where(c => c.Id == _httpService.CurrentUserId)
            .FirstAsync(cancellationToken);
       return (await _repository.Query<Shop>()
                .Where(s => s.Area.CityId == user.CityId)
                .Include(s => s.Area)
                .Include(s => s.WorkTimes)
                .Include(s => s.Category)
                .ToListAsync(cancellationToken))
            .Select(GetHomeQuery.Response.Selector())
            .ToList();
    }
}