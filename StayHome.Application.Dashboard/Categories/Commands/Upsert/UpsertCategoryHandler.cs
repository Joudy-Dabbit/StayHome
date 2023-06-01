using Application.Dashboard.Core.Abstractions;
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
    private readonly IFileService _fileService;

    public UpsertCategoryHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }


    public async Task<OperationResponse<GetAllCategoriesQuery.Response>> HandleAsync(UpsertCategoryCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var category = await _repository.TrackingQuery<Category>()
            .Where(c => request.Id.HasValue && c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        var imageUrl = await _fileService.Upload(request.ImageFile);

        if (category is null)
        {
            category = new Category(request.Name, imageUrl);
             _repository.Add(category);
        }
        else
        {
            category.Modify(request.Name, imageUrl);
        }
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return await _repository.GetAsync(category.Id, GetAllCategoriesQuery.Response.Selector());
    }
}