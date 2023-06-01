namespace Domain.Entities;

public class Category : AggregateRoot
{
    private Category() { }

    public Category(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
    
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();
    
    public void Modify(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }
}