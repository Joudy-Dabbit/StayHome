using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class AddAddressCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public string HouseNumber { get; private set; }
        public string Street { get; private set; } 
        public string? Additional { get; private set; }
    }
}