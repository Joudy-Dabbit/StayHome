using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class AddProductHandler : IRequestHandler<AddProductCommand.Request,
    OperationResponse<GetAllProductsByShopIdQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;
    
    public AddProductHandler(IFileService fileService, IStayHomeRepository repository)
    {
        _fileService = fileService;
        _repository = repository;
    }

    public async Task<OperationResponse<GetAllProductsByShopIdQuery.Response>> HandleAsync(AddProductCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        
        var shop = await _repository.TrackingQuery<Shop>()
            .Where(b => b.Id == request.ShopId).FirstAsync(cancellationToken);
        var image = await _fileService.Upload(request.ImageFile);
        var product = shop.AddProduct(request.Name,image, request.Cost, request.IsAvailable);
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return (await _repository.GetAsync(s => s.ShopId == shop.Id && s.Id == product.Id, GetAllProductsByShopIdQuery.Response.Selector())).First();
    }
}