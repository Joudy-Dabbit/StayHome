using Domain.Enum;

namespace Domain.Entities.Main;

public class Vehicle : AggregateRoot
{
    private Vehicle(){}
    public Vehicle(VehicleType type, double maxCapacity, 
        string color, string number)
    {
        Type = type;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
    
    public VehicleType Type { get; private set; }    
    public string Color { get; private set; }    
    public string Number { get; private set; }    
    public double MaxCapacity { get; private set; }

    public void Modify(VehicleType type, double maxCapacity, 
        string color, string number)
    {
        Type = type;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
}