using Microsoft.IdentityModel.Tokens;

namespace Domain.Entities;

public class AddressOrder : AggregateRoot
{
    private AddressOrder() { }
    
    public AddressOrder(string houseNumber, string street, 
        string? additional, Guid areaId, string floor)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
        AreaId = areaId;
        Floor = floor;
    }
    
    public Guid AreaId { get; private set; }
    public Area Area { get; private set; }
    
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    
    public string HouseNumber { get; private set; }
    public string Street { get; private set; } 
    public string? Additional { get; private set; }
    public string Floor { get; private set; }

    public override string ToString()
    {
        return string.Join(",",new []{ Street, Additional, HouseNumber}.Where(s => !s.IsNullOrEmpty()));
    }
}