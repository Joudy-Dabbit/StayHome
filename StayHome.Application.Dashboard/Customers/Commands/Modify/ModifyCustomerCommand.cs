using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class ModifyCustomerCommand
{
    public class Request: IRequest<OperationResponse<GetByIdCustomerQuery.Response>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } 
        
        public IFormFile? ImageFile { get; set; }
        public string? Password { get; set; }

        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public Guid CityId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}