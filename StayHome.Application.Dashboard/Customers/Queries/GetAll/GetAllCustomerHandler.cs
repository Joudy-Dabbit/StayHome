using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery.Request,
        OperationResponse<List<GetAllCustomerQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAllCustomerHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllCustomerQuery.Response>>> HandleAsync(GetAllCustomerQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllCustomerQuery.Response.Selector());
}