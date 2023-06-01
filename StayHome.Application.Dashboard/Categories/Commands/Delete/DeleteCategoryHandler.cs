using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public DeleteCategoryHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteCategoryCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDelete = await _repository.TrackingQuery<Category>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);
         _repository.SoftDelete(toDelete);
         
        return OperationResponse.WithOk();
    }
}