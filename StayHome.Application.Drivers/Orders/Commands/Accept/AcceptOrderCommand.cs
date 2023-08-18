using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class AcceptOrderCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
    }
}