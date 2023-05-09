
namespace Domain.Entities;

public class ShippingOrder : Order
{
    public double Weight { get; private set; }
    public double Coast { get; private set; }
    public PersonOrderVo PersonInfo { get; private set; }

    public Guid CityId { get; private set; }
    public City City { get; private set; }  
    
    public Guid? ShopId { get; private set; }
    public Shop? Shop { get; private set; }
    
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}