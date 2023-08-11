using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Mobile.Orders;

public class AddDeliveryOrderCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public AddressOrderDto Source { get; set; }
        public string? Note { get; private set; }
        
        public DateTime? ScheduleDate { get; set; }
        
        public Guid? ShopId { get; set; }
        public AddressOrderDto? Destination { get; set; }
        
        public double? Weight { get; set; }
        public List<ProductsCartDto>? Cart { get; set; } = new();
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