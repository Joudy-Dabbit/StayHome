
namespace Domain.Entities;

public class ShippingOrder : Order
{
    private ShippingOrder() { }

    public ShippingOrder(double coast, double? weight,
        Guid? shopId, DateTime? scheduleDate, 
        double deliveryCoast, string? note,
        Guid destinationId, Guid? sourceId, Guid customerId)
    {
        Coast = coast;
        Weight = weight;
        ScheduleDate = scheduleDate;
        ShopId = shopId;
        DeliveryCoast = deliveryCoast;
        Note = note;
        DestinationId = destinationId;
        SourceId = sourceId;
        CustomerId = customerId;
    }
    
    public double? Weight { get; private set; }

    public Guid? ShopId { get; private set; }
    public Shop? Shop { get; private set; }
    
    private readonly List<ShippingOrderCart> _carts = new();
    public IReadOnlyCollection<ShippingOrderCart> Carts => _carts.AsReadOnly();

    public void AddOrderCart(Guid productId,int quantity)
    {
        var orderCart = new ShippingOrderCart(quantity, productId,Id);
        _carts.Add(orderCart);
    }
}