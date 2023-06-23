using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class ModifyVehicleCommand
{
    public class Request : IRequest<OperationResponse<GetByIdVehicleQuery.Response>>
    {
        public Guid Id { get; set; }
        public Guid VehicleTypeId { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public double MaxCapacity { get; set; }
    }
}