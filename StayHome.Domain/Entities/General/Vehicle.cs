using Domain.Enum;

namespace Domain.Entities;

public class Vehicle : AggregateRoot
{
    private Vehicle()
    {
    }
    
    public Vehicle(string name, Guid vehicleTypeId, double maxCapacity, 
        string color, string number, string imageUrl)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
        ImageUrl = imageUrl;
        Name = name;
    }
    
    public Guid VehicleTypeId { get; private set; }    
    public VehicleType VehicleType { get; private set; }
    
    public string Color { get; private set; }    
    public string Number { get; private set; }    
    public string Name { get; private set; }    
    public double MaxCapacity { get; private set; }
    public string ImageUrl { get; private set; }

    public void Modify(string name, Guid vehicleTypeId, double maxCapacity, 
        string color, string number, string imageUrl)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
        Name = name;
        ImageUrl = imageUrl;
    }
}