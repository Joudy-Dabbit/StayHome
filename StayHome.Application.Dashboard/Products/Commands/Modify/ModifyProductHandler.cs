using System.Net.Mime;
using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class ModifyProductHandler : IRequestHandler<ModifyProductCommand.Request,
    OperationResponse<GetByIdProductQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;
    
    public ModifyProductHandler( IFileService fileService, IStayHomeRepository repository)
    {
        _fileService = fileService;
        _repository = repository;
    }

    public async Task<OperationResponse<GetByIdProductQuery.Response>> HandleAsync(ModifyProductCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var product = await _repository.TrackingQuery<Product>()
            .Where(p => p.Id == request.Id).FirstAsync(cancellationToken);

        var  Image = await _fileService.Modify(product.ImageUrl, request.ImageFile);
        product.Modify(request.Name, Image, request.Cost, request.IsAvailable);
     
        _repository.Update(product);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(product.Id, GetByIdProductQuery.Response.Selector());
    }
}