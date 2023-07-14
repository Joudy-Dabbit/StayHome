namespace Domain.Entities;

public class Address : AggregateRoot
{
    private Address() { }
    
    public Address(Guid customerId, string houseNumber, string street,
        string? additional, Guid areaId, string name, string floor)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
        AreaId = areaId;
        Name = name;
        CustomerId = customerId;
    }

    public string Name { get; private set; }
    public string HouseNumber { get; private set; }
    public string Street { get; private set; } 
    public string Floor { get; private set; }
    public string? Additional { get; private set; }

    public Guid AreaId { get; private set; }
    public Area Area { get; private set; }  
    
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    
    public void Modify(string name, Guid areaId, 
        string houseNumber, string street,
        string? additional, string floor)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
        AreaId = areaId;
        Name = name;
        Floor = floor;
    }
}