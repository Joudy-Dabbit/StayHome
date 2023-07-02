using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Shops;

public class GetAllShopsHandler : IRequestHandler<GetAllShopsQuery.Request,
    OperationResponse<List<GetAllShopsQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllShopsHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllShopsQuery.Response>>> HandleAsync(GetAllShopsQuery.Request request,
        CancellationToken cancellationToken = new())
        => (await _repository.Query<Category>()
            .Include(s => s.Shops)
            .ThenInclude(s => s.WorkTimes) 
            .Include(s => s.Shops)
            .ThenInclude(s => s.Area)
            .ThenInclude(s => s.City)
            .ToListAsync(cancellationToken))
            .Select(GetAllShopsQuery.Response.Selector())
            .ToList();
}