using Domain.Entities;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Orders;

public class AddShippingOrderHandler : IRequestHandler<AddShippingOrderCommand.Request, 
    OperationResponse>
{
    private readonly IHttpService _httpResolverService;
    private readonly IUserRepository _repository;
    private readonly IOrderRepository _orderRepository;

    public AddShippingOrderHandler(IHttpService httpResolverService, 
        IUserRepository repository, IOrderRepository orderRepository)
    {
        _httpResolverService = httpResolverService;
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<OperationResponse> HandleAsync(AddShippingOrderCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var sourceArea = request.ShopId.HasValue
            ? _orderRepository.Query<Shop>()
                .First(s => s.Id == request.ShopId).AreaId
            : request.Source!.AreaId;
        var deliveryCoast = await _orderRepository.DeliveryCoast(sourceArea, request.Destination!.AreaId);
        var destination = new AddressOrder(request.Destination.Street, request.Destination.Additional,
            request.Destination.AreaId);
        _repository.Add(destination);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        AddressOrder source = null;
        if(request.Source is not null )
        {
           source = new AddressOrder(request.Source.Street, request.Source.Additional,
                request.Source.AreaId);
            _repository.Add(source);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        var cost = request.Cart is not null
            ? await _orderRepository.TotalProductPrice(request.Cart.Select(p => p.ProductId).ToList())
            : 0;
        var order = new ShippingOrder(cost, request.Weight, request.ShopId,
            request.ScheduleDate, deliveryCoast, request.Note,
            destination.Id, source!.Id);
            
        if(request.Cart.Any())
               request.Cart.ForEach(c => order.AddOrderCart(c.ProductId, c.Quantity));

        _repository.Add(order);
        await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}