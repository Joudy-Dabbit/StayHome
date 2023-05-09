using Domain.Enum;

namespace Domain.Entities;

public class Vehicle : AggregateRoot
{
    private Vehicle(){}
    
    public Vehicle(Guid vehicleTypeId, double maxCapacity, 
        string color, string number)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
    
    public Guid VehicleTypeId { get; private set; }    
    public VehicleType VehicleType { get; private set; }    
    
    public string Color { get; private set; }    
    public string Number { get; private set; }    
    public double MaxCapacity { get; private set; }

    public void Modify(Guid vehicleTypeId, double maxCapacity, 
        string color, string number)
    {
        VehicleTypeId = vehicleTypeId;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
}