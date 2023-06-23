using Domain.Enum;

namespace Domain.Entities;

public class Vehicle : AggregateRoot
{
    private Vehicle()
    {
    }
    
    public Vehicle(string name, Guid vehicleTypeId, double maxCapacity, 
        string color, string number)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
        Name = name;
    }
    
    public Guid VehicleTypeId { get; private set; }    
    public VehicleType VehicleType { get; private set; }    
    
    public string Color { get; private set; }    
    public string Number { get; private set; }    
    public string Name { get; private set; }    
    public double MaxCapacity { get; private set; }
    
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    
    public void Modify(string name, Guid vehicleTypeId, double maxCapacity, 
        string color, string number)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
        Name = name;
    }
}