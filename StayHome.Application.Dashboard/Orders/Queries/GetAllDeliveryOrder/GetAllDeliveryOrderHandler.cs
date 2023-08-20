using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllDeliveryOrderHandler: IRequestHandler<GetAllDeliveryOrderQuery.Request,
    OperationResponse<List<GetAllDeliveryOrderQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAllDeliveryOrderHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllDeliveryOrderQuery.Response>>> HandleAsync(GetAllDeliveryOrderQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(e => !e.UtcDateDeleted.HasValue,
            GetAllDeliveryOrderQuery.Response.Selector());
}