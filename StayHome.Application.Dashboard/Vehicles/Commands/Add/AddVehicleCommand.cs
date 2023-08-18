using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class AddVehicleCommand
{
    public class Request : IRequest<OperationResponse<GetAllVehiclesQuery.Response>>
    {
        public Guid VehicleTypeId { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
        public double MaxCapacity { get; set; }
    }
}