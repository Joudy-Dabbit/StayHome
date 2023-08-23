using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetAvailableDriversHandler: IRequestHandler<GetAvailableDriversQuery.Request,
    OperationResponse<List<GetAvailableDriversQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAvailableDriversHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAvailableDriversQuery.Response>>> HandleAsync(GetAvailableDriversQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(d =>
                d.Orders.All(e => e.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage != OrderStages.OnWay),
            GetAvailableDriversQuery.Response.Selector());
}