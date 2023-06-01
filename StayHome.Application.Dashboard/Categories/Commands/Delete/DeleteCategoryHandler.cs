using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;

    public DeleteCategoryHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResponse> HandleAsync(DeleteCategoryCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDelete = await _repository.TrackingQuery<Category>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);
         _repository.SoftDelete(toDelete);
         
         toDelete.ForEach(category => _fileService.Delete(category.ImageUrl));
        return OperationResponse.WithOk();
    }
}