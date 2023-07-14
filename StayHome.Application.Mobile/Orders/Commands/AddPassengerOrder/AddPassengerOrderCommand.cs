using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Mobile.Orders;

public class AddPassengerOrderCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public string? Note { get; private set; }
        public DateTime? ScheduleDate { get; set; }
        
        public AddressOrderDto Source { get; set; }
        public AddressOrderDto Destination { get; set; }

        public double NumberOfPassenger { get; set; }
    }
}