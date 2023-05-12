using Domain;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class GetAllEmployeesHandler: IRequestHandler<GetAllEmployeesQuery.Request, OperationResponse<List<GetAllEmployeesQuery.Response>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllEmployeesHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<List<GetAllEmployeesQuery.Response>>> HandleAsync(GetAllEmployeesQuery.Request request, CancellationToken cancellationToken = new CancellationToken())
        => await _userRepository.GetAsync(GetAllEmployeesQuery.Response.Selector());
}