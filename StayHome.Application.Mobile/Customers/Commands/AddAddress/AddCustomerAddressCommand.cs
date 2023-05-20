using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shared.Addresses;

namespace StayHome.Application.Mobile.Customers;

public class AddCustomerAddressCommand
{
    public class Request : AddAddressRequest, IRequest<OperationResponse>
    {

    }
}