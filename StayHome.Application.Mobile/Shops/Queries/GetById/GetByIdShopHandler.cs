using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Shops;

public class GetByIdShopHandler : IRequestHandler<GetByIdShopQuery.Request,
    OperationResponse<GetByIdShopQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdShopHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdShopQuery.Response>> HandleAsync(GetByIdShopQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(request.Id, GetByIdShopQuery.Response.Selector());
    
        // =>  (await _repository.Query<Shop>()
        //     .Include(s => s.WorkTimes)
        //     .Include(s => s.Products)
        //     .Include(s => s.Area)
        //     .ThenInclude(s => s.City)
        //     .Where(s => s.Id == request.Id)
        //     .ToListAsync(cancellationToken))
        //     .Select(GetByIdShopQuery.Response.Selector())
        //     .First();
}