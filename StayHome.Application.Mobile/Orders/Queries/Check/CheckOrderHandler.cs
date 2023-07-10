using Domain.Entities;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Orders;

public class CheckOrderHandler : IRequestHandler<CheckOrderQuery.Request, 
    OperationResponse<CheckOrderQuery.Response>>
{
    private readonly IAreaPriceRepository _areaPriceRepository;

    public CheckOrderHandler(IAreaPriceRepository areaPriceRepository)
    {
        _areaPriceRepository = areaPriceRepository;
    }

    public async Task<OperationResponse<CheckOrderQuery.Response>> HandleAsync(CheckOrderQuery.Request request, 
        CancellationToken cancellationToken = new())
    {
        var sourceArea = request.ShopId.HasValue
            ? _areaPriceRepository.Query<Shop>()
                .First(s => s.Id == request.ShopId).AreaId
            : request.SourceAreaId!.Value;
        var deliveryCoastResult = await _areaPriceRepository.DeliveryCoast(sourceArea, request.DestinationAreaId);

        return new CheckOrderQuery.Response(deliveryCoastResult);
    }
}