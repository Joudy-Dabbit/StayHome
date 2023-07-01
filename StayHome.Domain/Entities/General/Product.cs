namespace Domain.Entities;

public class Product : AggregateRoot
{
    private Product() { }
    
    public Product(string name,string imageUrl, double cost, Guid shopId)
    {
        Cost = cost;
        Name = name;
        ImageUrl = imageUrl;
    }
    
    public string Name { get; private set; }
    public string ImageUrl { get; set; }
    public double Cost { get; private set; }

    public Guid ShopId { get; private set; }
    public Shop  Shop { get; private set; }
    
    private readonly List<ShippingOrderCart> _shippingOrderCarts = new();
    public IReadOnlyCollection<ShippingOrderCart> ShippingOrderCarts => _shippingOrderCarts.AsReadOnly();
    
    
    private readonly List<DeliveryOrderCart> _deliveryOrderCarts = new();
    public IReadOnlyCollection<DeliveryOrderCart> DeliveryOrderCarts => _deliveryOrderCarts.AsReadOnly();

    public void Modify(string name,string imageUrl, double cost)
    {
        Cost = cost;
        Name = name;
        ImageUrl = imageUrl;
    }
}