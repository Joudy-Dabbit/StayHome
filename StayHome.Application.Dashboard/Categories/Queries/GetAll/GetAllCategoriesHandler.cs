using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery.Request,
    OperationResponse<List<GetAllCategoriesQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetAllCategoriesHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetAllCategoriesQuery.Response>>> HandleAsync(GetAllCategoriesQuery.Request request, 
        CancellationToken cancellationToken = new())
        => await _repository.GetAsync(GetAllCategoriesQuery.Response.Selector());
}