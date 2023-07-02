using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class GetAllSopsHandler : IRequestHandler<GetAllSopsQuery.Request,
    OperationResponse<List<GetAllSopsQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;
    
    public GetAllSopsHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllSopsQuery.Response>>> HandleAsync(GetAllSopsQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
        => (await _repository.Query<Shop>()
                .Include(s => s.WorkTimes)
                .ToListAsync(cancellationToken))
            .Select(GetAllSopsQuery.Response.Selector())
            .ToList();
}