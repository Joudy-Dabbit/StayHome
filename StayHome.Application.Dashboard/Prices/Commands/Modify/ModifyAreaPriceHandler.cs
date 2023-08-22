using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class ModifyAreaPriceHandler: IRequestHandler<ModifyAreaPriceCommand.Request,OperationResponse<GetAllAreaPricesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public ModifyAreaPriceHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetAllAreaPricesQuery.Response>> HandleAsync(ModifyAreaPriceCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var areaPrice = await _repository.TrackingQuery<AreaPrice>()
            .Where(ap => ap.Id == request.Id)
            .FirstAsync(cancellationToken);
        areaPrice.Modify(request.Price, request.TimeBetween);

        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(areaPrice.Id, GetAllAreaPricesQuery.Response.Selector());
    }
}