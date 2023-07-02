using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class AddShopHandler : IRequestHandler<AddShopCommand.Request,
    OperationResponse<GetAllSopsQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;
    public AddShopHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResponse<GetAllSopsQuery.Response>> HandleAsync(AddShopCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var imageUrl = await _fileService.Upload(request.ImageFile);
        
        var shop = new Shop(request.Name, imageUrl, 
            request.CategoryId, request.AreaId);

        request.WorkTimes.ForEach(w =>
        {
            shop.AddWorkTime(w.DayOfWeek, w.StartTime, w.EndTime);
        });
        
        _repository.Add(shop);        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return (await _repository.Query<Shop>()
                .Include(s => s.WorkTimes)
                .Where(s => s.Id == shop.Id)
                .ToListAsync(cancellationToken))
            .Select(GetAllSopsQuery.Response.Selector())
            .First();;
    }
}