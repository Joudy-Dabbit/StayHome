using Domain.Events;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.DomainEvents;

namespace StayHome.Application.Dashboard.Areas.Events;

public class AddAreaPriceEventHandler: IDomainEventHandler<AddAreaPriceEvent>
{
    private readonly IOrderRepository _orderRepository;

    public AddAreaPriceEventHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task HandleAsync(AddAreaPriceEvent domainEvent, 
        CancellationToken cancellationToken = new())
    {
        await _orderRepository.Add(domainEvent.Area.Id);
    }
}