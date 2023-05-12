using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery.Request,
    OperationResponse<GetByIdEmployeeQuery.Response>>
{
    private readonly IUserRepository _userRepository;

    public GetByIdEmployeeHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<GetByIdEmployeeQuery.Response>> HandleAsync(GetByIdEmployeeQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
        => await _userRepository.GetAsync(request.Id, GetByIdEmployeeQuery.Response.Selector);
}