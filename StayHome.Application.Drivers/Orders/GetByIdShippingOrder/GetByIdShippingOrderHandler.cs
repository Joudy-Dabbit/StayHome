using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdShippingOrderHandler: IRequestHandler<GetByIdShippingOrderQuery.Request,
    OperationResponse<GetByIdShippingOrderQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdShippingOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdShippingOrderQuery.Response>> HandleAsync(GetByIdShippingOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(request.Id, GetByIdShippingOrderQuery.Response.Selector);
}