using Domain.Entities;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Orders;

public class GetDeliveryCostHandler : IRequestHandler<GetDeliveryCostQuery.Request, 
    OperationResponse<GetDeliveryCostQuery.Response>>
{
    private readonly IOrderRepository _orderRepository;

    public GetDeliveryCostHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResponse<GetDeliveryCostQuery.Response>> HandleAsync(GetDeliveryCostQuery.Request request, 
        CancellationToken cancellationToken = new())
    {
        var sourceArea = request.ShopId.HasValue
            ? _orderRepository.Query<Shop>()
                .First(s => s.Id == request.ShopId).AreaId
            : request.SourceAreaId!.Value;
        var deliveryCoastResult = await _orderRepository.DeliveryCoast(sourceArea, request.DestinationAreaId);

        return new GetDeliveryCostQuery.Response(deliveryCoastResult);
    }
}