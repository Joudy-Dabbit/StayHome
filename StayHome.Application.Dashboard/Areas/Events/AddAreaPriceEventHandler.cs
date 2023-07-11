using Domain.Events;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.DomainEvents;

namespace StayHome.Application.Dashboard.Areas.Events;

public class AddAreaPriceEventHandler: IDomainEventHandler<AddAreaPriceEvent>
{
    private readonly IAreaPriceRepository _areaPriceRepository;

    public AddAreaPriceEventHandler(IAreaPriceRepository areaPriceRepository)
    {
        _areaPriceRepository = areaPriceRepository;
    }

    public async Task HandleAsync(AddAreaPriceEvent domainEvent, 
        CancellationToken cancellationToken = new())
    {
        await _areaPriceRepository.Add(domainEvent.Area.CityId, domainEvent.Area.Id);
    }
}