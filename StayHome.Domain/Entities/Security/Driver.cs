namespace Domain.Entities;

public class Driver : User
{
    private Driver() { }

    public string? DeviceToken { get; private set; }
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
}