using Domain.Enum;

namespace Domain.Entities.Main;

public class Transportation : AggregateRoot
{
    private Transportation(){}
    public Transportation(TransportationType type, double maxCapacity, 
        string color, string number)
    {
        Type = type;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
    
    public TransportationType Type { get; private set; }    
    public string Color { get; private set; }    
    public string Number { get; private set; }    
    public double MaxCapacity { get; private set; }

    public void Modify(TransportationType type, double maxCapacity, 
        string color, string number)
    {
        Type = type;
        MaxCapacity = maxCapacity;
        Color = color;
        Number = number;
    }
}