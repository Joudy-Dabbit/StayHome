using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class GetAllAreaPricesHandler : IRequestHandler<GetAllAreaPricesQuery.Request,
    OperationResponse<List<GetAllAreaPricesQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllAreaPricesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllAreaPricesQuery.Response>>> HandleAsync(GetAllAreaPricesQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllAreaPricesQuery.Response.Selector());
}