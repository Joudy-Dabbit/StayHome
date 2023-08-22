using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Mobile.Orders;

public class AddPassengerOrderCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public string? Note { get; set; }
        public DateTime? ScheduleDate { get; set; }
        
        public AddressOrderDto Source { get; set; }
        public AddressOrderDto Destination { get; set; }

        public int NumberOfPassenger { get; set; }
    }
    public class Response
    {
        public Guid Id { get; set; }

        public Response(Guid id)
        {
            Id = id;
        }
    }
}