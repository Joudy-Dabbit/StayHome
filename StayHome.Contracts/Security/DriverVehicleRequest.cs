using Microsoft.AspNetCore.Http;

namespace StayHome.Contracts.Security;

public class DriverVehicleRequest
{
    public Guid VehicleTypeId { get; set; }
    public string Color { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public IFormFile ImageFile { get; set; }
    public double MaxCapacity { get; set; }
}