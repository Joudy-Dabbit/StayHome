namespace Domain.Entities;

public class DeliveryOrderCart : AggregateRoot
{
    private DeliveryOrderCart() { }
   
    public DeliveryOrderCart(int quantity, Guid productId, Guid orderId)
    {
        Quantity = quantity;
        ProductId = productId;
        OrderId = orderId;
    }
    
    public int Quantity { get; private set; }
   
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
   
    public Guid OrderId { get; private set; }
    public DeliveryOrder Order { get; private set; }
}