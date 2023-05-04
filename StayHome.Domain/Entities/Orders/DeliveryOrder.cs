using Domain.Entities.Main;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Orders;

public class DeliveryOrder : Order
{
    public double Coast { get; set; }
    public PersonOrderVo PersonInfo { get; private set; }

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}