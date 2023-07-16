namespace Domain.Entities;

public class DeliveryOrder : Order
{
    public double Coast { get; set; }

    public Guid? ShopId { get; private set; }
    public Shop? Shop { get; private set; }
    

    private readonly List<DeliveryOrderCart> _carts = new();
    public IReadOnlyCollection<DeliveryOrderCart> Carts => _carts.AsReadOnly();
}