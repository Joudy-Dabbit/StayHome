using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetDriverNamesHandler : IRequestHandler<GetDriverNamesQuery.Request,
    OperationResponse<List<GetDriverNamesQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetDriverNamesHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetDriverNamesQuery.Response>>> HandleAsync(GetDriverNamesQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetDriverNamesQuery.Response.Selector());
}