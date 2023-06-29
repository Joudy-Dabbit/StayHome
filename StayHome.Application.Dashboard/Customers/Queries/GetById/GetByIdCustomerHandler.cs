
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class GetByIdCustomerHandler
    : IRequestHandler<GetByIdCustomerQuery.Request, OperationResponse<GetByIdCustomerQuery.Response>>
{   
    private readonly IUserRepository _userRepository;

    public GetByIdCustomerHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<GetByIdCustomerQuery.Response>> HandleAsync(GetByIdCustomerQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _userRepository.GetAsync(request.Id, GetByIdCustomerQuery.Response.Selector());
}