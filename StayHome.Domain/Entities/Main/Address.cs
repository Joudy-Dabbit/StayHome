namespace Domain.Entities;

public class Address : AggregateRoot
{
    private Address(string name)
    {
        Name = name;
    }
    
    public Address(string houseNumber, string street,
        string? additional, Guid areaId, string name)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
        AreaId = areaId;
        Name = name;
    }

    public string Name { get; private set; }
    public string HouseNumber { get; private set; }
    public string Street { get; private set; } 
    public string? Additional { get; private set; }

    public Guid AreaId { get; private set; }
    public Area Area { get; private set; }
}