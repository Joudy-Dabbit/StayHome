namespace Domain.Entities;

public class VehicleType
{
    //private VehicleType() { }

    public VehicleType(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void Modify(string name)
    {
        Name = name;
    }
}