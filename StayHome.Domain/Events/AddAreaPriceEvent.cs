using Domain.Entities;
using Neptunee.BaseCleanArchitecture.DomainEvents;

namespace Domain.Events;
public class AddAreaPriceEvent : IDomainEvent
{
    public AddAreaPriceEvent(Area area)
    {
        Area = area;
    }
    public Area Area { get; set; }
}
