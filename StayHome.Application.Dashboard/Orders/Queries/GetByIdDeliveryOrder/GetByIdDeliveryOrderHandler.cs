using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetByIdDeliveryOrderHandler: IRequestHandler<GetByIdDeliveryOrderQuery.Request,
    OperationResponse<GetByIdDeliveryOrderQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdDeliveryOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdDeliveryOrderQuery.Response>> HandleAsync(GetByIdDeliveryOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(request.Id, GetByIdDeliveryOrderQuery.Response.Selector);
}