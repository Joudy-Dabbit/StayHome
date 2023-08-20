using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Orders;

public class CancelOrderCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
    }
}