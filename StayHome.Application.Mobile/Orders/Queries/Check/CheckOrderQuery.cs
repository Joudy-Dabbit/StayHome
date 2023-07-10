using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Orders;

public class CheckOrderQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid? SourceAreaId { get; set; }
        public Guid? ShopId { get; set; }
        public Guid DestinationAreaId { get; set; }

    }

    public class Response 
    { 
        public double DeliveryCoast { get; set; }
        public Response(double deliveryCoast)
        {
            DeliveryCoast = deliveryCoast;
        }
    }
}