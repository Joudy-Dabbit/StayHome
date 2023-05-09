namespace Domain.Entities;

public class Area : AggregateRoot
{
    private Area()
    {
    }
    
    public Area(string name, Guid cityId)
    {
        Name = name;
        CityId = cityId;
    }
    
    public string Name { get; set; }
    public Guid CityId { get; private set; }
    public City City { get; private set; }
    
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();

    // private readonly List<Customer> _customers = new();
    // public IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();

    public void Modify(string name)
    {
        Name = name;
    }
}