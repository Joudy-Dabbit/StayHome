using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllRejectedOrderHandler: IRequestHandler<GetAllRejectedOrderQuery.Request,
    OperationResponse<List<GetAllRejectedOrderQuery.Response>>>
{
    private readonly IUserRepository _repository;

    public GetAllRejectedOrderHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllRejectedOrderQuery.Response>>> HandleAsync(GetAllRejectedOrderQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(e => !e.UtcDateDeleted.HasValue
        && e.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage == OrderStages.Rejected,
            GetAllRejectedOrderQuery.Response.Selector);
}