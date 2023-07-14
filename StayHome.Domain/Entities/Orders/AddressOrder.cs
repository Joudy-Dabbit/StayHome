using Microsoft.IdentityModel.Tokens;

namespace Domain.Entities;

public class AddressOrder : AggregateRoot
{
    private AddressOrder() { }
    
    public AddressOrder(string street, 
        string? additional, Guid areaId)
    {
        Street = street;
        Additional = additional;
        AreaId = areaId;
    }
    
    public Area Area { get; private set; }
    public Guid AreaId { get; private set; }

    public string Street { get; private set; } 
    public string? Additional { get; private set; }

    public ICollection<Order> DestinationOrders { get; set; }
    public ICollection<Order> SourceOrders { get; set; }
    
    public override string ToString()
    {
        return string.Join(",",new []{ Street, Additional}.Where(s => !s.IsNullOrEmpty()));
    }
}