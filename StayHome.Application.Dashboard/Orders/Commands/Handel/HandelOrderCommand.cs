using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class HandelOrderCommand
{
    public class Request : IRequest<OperationResponse<GetByIdShippingOrderQuery.Response>>
    {  
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid VehicleId { get; set; }
    }
}