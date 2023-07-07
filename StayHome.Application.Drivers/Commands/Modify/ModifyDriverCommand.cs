using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers;

public class ModifyDriverCommand
{
    public class Request : IRequest<OperationResponse<GetDriverProfileQuery.Response>>  
    {
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}