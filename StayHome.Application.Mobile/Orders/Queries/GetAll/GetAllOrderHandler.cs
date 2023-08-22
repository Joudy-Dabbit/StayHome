using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Orders;

public class GetAllOrderHandler: IRequestHandler<GetAllOrderQuery.Request,
    OperationResponse<List<GetAllOrderQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IHttpService _httpService;

    public GetAllOrderHandler(IStayHomeRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<List<GetAllOrderQuery.Response>>> HandleAsync(GetAllOrderQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.Query<Order>()
            .Where(o => o.CustomerId == _httpService.CurrentUserId!.Value)
            .Select(GetAllOrderQuery.Response.Selector)
            .OrderByDescending(o => o.DateCreated)
            .ToListAsync(cancellationToken);

}