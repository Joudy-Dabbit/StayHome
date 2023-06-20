using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class GetAllProductsByShopIdHandler : IRequestHandler<GetAllProductsByShopIdQuery.Request,
OperationResponse<List<GetAllProductsByShopIdQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllProductsByShopIdHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllProductsByShopIdQuery.Response>>> HandleAsync(GetAllProductsByShopIdQuery.Request request, 
        CancellationToken cancellationToken = new())
    =>  await _repository.GetAsync(p => p.ShopId == request.ShopId, 
        GetAllProductsByShopIdQuery.Response.Selector());
}