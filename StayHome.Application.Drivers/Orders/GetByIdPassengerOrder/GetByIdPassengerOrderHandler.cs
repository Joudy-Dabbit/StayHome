using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdPassengerOrderHandler: IRequestHandler<GetByIdPassengerOrderQuery.Request,
    OperationResponse<GetByIdPassengerOrderQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdPassengerOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdPassengerOrderQuery.Response>> HandleAsync(GetByIdPassengerOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(request.Id, GetByIdPassengerOrderQuery.Response.Selector);
}