using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shared.Addresses;

namespace StayHome.Application.Dashboard.Customers;

public class AddCustomerCommand
{
    public class Request : IRequest<OperationResponse<GetAllCustomerQuery.Response>>
    {  
        public string FullName { get; set; }
        public string PhoneNumber { get; set; } 
        public IFormFile? ImageFile { get; set; }
        public string Password { get; set; }
        public Gender Gender { get;  set; }
        public string Email { get; set; } 
        public Guid CityId { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public AddAddressRequest Address { get; set; }
    }
}