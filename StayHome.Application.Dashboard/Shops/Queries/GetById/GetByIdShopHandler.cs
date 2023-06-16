using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

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
        => await _repository.GetAsync(request.Id, GetByIdShopQuery.Response.Selector);
}