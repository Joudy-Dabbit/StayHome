using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllShippingOrderHandler: IRequestHandler<GetAllShippingOrderQuery.Request,
    OperationResponse<List<GetAllShippingOrderQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAllShippingOrderHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllShippingOrderQuery.Response>>> HandleAsync(GetAllShippingOrderQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(e => !e.UtcDateDeleted.HasValue,
            GetAllShippingOrderQuery.Response.Selector());
}