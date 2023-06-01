using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class ModifyEmployeeCommand
{
    public class Request : IRequest<OperationResponse<GetByIdEmployeeQuery.Response>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public IFormFile? ImageFile { get; set; }
        
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
    }
}