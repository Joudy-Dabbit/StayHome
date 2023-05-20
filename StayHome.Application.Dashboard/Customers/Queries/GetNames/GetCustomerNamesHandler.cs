using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class GetCustomerNamesHandler : IRequestHandler<GetCustomerNamesQuery.Request,
    OperationResponse<List<GetCustomerNamesQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetCustomerNamesHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetCustomerNamesQuery.Response>>> HandleAsync(GetCustomerNamesQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetCustomerNamesQuery.Response.Selector());
}