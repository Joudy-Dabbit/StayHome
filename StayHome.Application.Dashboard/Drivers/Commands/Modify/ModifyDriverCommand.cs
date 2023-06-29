using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class ModifyDriverCommand
{
    public class Request: IRequest<OperationResponse<GetByIdDriverQuery.Response>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? Password { get; set; }

        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public DateTime? BirthDate { get; set; }
    }
}