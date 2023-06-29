using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery.Request,
    OperationResponse<List<GetAllDriversQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAllDriversHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllDriversQuery.Response>>> HandleAsync(GetAllDriversQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(e => !e.UtcDateDeleted.HasValue,
            GetAllDriversQuery.Response.Selector());
}