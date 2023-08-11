namespace StayHome.Contracts.Security;

public class DriverVehicleResponse
{
    public Guid VehicleTypeId { get; set; }
    public string Color { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string ImageFile { get; set; }
    public double MaxCapacity { get; set; }
}