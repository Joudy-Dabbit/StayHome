using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetByIdDriverHandler : IRequestHandler<GetByIdDriverQuery.Request,
    OperationResponse<GetByIdDriverQuery.Response>>
{   
    private readonly IUserRepository _userRepository;

    public GetByIdDriverHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse<GetByIdDriverQuery.Response>> HandleAsync(GetByIdDriverQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _userRepository.GetAsync(request.Id, GetByIdDriverQuery.Response.Selector());
}