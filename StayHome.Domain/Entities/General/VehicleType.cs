namespace Domain.Entities;

public class VehicleType
{
    private VehicleType() { }

    public VehicleType(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    
    
    private readonly List<Vehicle> _vehicles = new();
    public IReadOnlyCollection<Vehicle> Orders => _vehicles.AsReadOnly();   
    
    public void Modify(string name)
    {
        Name = name;
    }
}