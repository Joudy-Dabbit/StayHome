using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class AddEmployeeCommand
{
    public class Request : IRequest<OperationResponse<GetAllEmployeesQuery.Response>>
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public IFormFile? ImageFile { get; set; }
        
        public string PhoneNumber { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Email { get; set; }
    }
}