namespace StayHome.Contracts.Orders;

public class ProductsCartReq
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}