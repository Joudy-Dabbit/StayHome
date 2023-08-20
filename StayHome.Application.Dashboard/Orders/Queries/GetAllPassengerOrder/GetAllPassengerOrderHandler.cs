using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllPassengerOrderHandler: IRequestHandler<GetAllPassengerOrderQuery.Request,
    OperationResponse<List<GetAllPassengerOrderQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllPassengerOrderHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllPassengerOrderQuery.Response>>> HandleAsync(GetAllPassengerOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllPassengerOrderQuery.Response.Selector);
}