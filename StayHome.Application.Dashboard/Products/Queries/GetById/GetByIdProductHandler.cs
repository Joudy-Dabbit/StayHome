using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery.Request,
    OperationResponse<GetByIdProductQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetByIdProductHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdProductQuery.Response>> HandleAsync(GetByIdProductQuery.Request request, 
        CancellationToken cancellationToken = new())
        =>  await _repository.GetAsync(request.Id, GetByIdProductQuery.Response.Selector());
}