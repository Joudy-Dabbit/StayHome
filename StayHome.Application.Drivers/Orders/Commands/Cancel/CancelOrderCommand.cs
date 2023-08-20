using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class CancelOrderCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
        public CancelBy CancelBy { get; set; }
        // public string Reason { get; set; }
    }
}