using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.VehicleTypes;

public class UpsertVehicleTypeCommand
{
    public class Request : IRequest<OperationResponse<GetAllVehicleTypesQuery.Response>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}