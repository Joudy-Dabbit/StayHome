using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class DeleteCustomerAddressCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
    }
}