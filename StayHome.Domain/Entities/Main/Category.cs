namespace Domain.Entities.Main;

public class Category : AggregateRoot
{
    private Category() { }

    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();
}