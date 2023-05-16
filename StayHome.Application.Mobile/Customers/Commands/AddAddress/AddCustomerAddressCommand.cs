using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class AddCustomerAddressCommand
{
    public class Request : IRequest<OperationResponse<Guid>>
    {
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; } 
        public string Floor { get; set; } 
        public string? Additional { get; set; }
    }
}