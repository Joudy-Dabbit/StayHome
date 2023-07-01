using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Mobile.Orders;

public class AddShippingOrderCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public DateTime? ScheduleDate { get; set; }
        public Guid? ShopId { get; set; }
        public double? Weight { get; set; }

        public AddressOrderDto? Destination { get; set; }
        public AddressOrderDto Source { get; set; }
        public string Note { get; private set; }

        public List<ProductsCartReq>? Products { get; set; } = new();
        
        public class ProductsCartReq
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}