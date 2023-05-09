namespace Domain.Entities;

public class City : AggregateRoot
{
    private City(){}
    public City(string name)
    {
        Name = name;
    }
    
    public string Name { get; private set; }

    private readonly List<Area> _areas = new();
    public IReadOnlyCollection<Area> Areas => _areas.AsReadOnly();

    // private readonly List<Customer> _customers = new();
    // public IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();

    public void Modify(string name)
    {
        Name = name;
    }
}