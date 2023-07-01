namespace Domain.Entities;

public class ShippingOrderCart : AggregateRoot
{
   private ShippingOrderCart() { }
   
   public ShippingOrderCart(int quantity, Guid productId, Guid orderId)
   {
      Quantity = quantity;
      ProductId = productId;
      OrderId = orderId;
   }
    
   public int Quantity { get; private set; }
   
   public Guid ProductId { get; private set; }
   public Product Product { get; private set; }
   
   public Guid OrderId { get; private set; }
   public ShippingOrder Order { get; private set; }
}