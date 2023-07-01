
namespace Domain.Entities;

public class ShippingOrder : Order
{
    public double Coast { get; private set; }
    public double? Weight { get; private set; }
    // public PersonOrderVo PersonInfo { get; private set; }
    public Guid CityId { get; private set; }
    public City City { get; private set; }  
    
    public Guid? ShopId { get; private set; }
    public Shop? Shop { get; private set; }
    
    private readonly List<ShippingOrderCart> _carts = new();
    public IReadOnlyCollection<ShippingOrderCart> Carts => _carts.AsReadOnly();

    public ShippingOrder(double coast, double? weight, Guid cityId)
    {
        Coast = coast;
        Weight = weight;
        CityId = cityId;
    }
}