using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class UpsertCategoryHandler : IRequestHandler<UpsertCategoryCommand.Request,
    OperationResponse<GetAllCategoriesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public UpsertCategoryHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResponse<GetAllCategoriesQuery.Response>> HandleAsync(UpsertCategoryCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var category = await _repository.TrackingQuery<Category>()
            .Where(c => request.Id.HasValue && c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (category is null)
        {
            category = new Category(request.Name);
             _repository.Add(category);
        }
        else
        {
            category.Modify(request.Name);
        }
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return await _repository.GetAsync(category.Id, GetAllCategoriesQuery.Response.Selector());
    }
}