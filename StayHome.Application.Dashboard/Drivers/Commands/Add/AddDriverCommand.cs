using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;
using StayHome.Contracts.Shared.Addresses;

namespace StayHome.Application.Dashboard.Drivers;

public class AddDriverCommand
{
    public class Request : IRequest<OperationResponse<GetAllDriversQuery.Response>>
    {  
        public string FullName { get; set; }
        public string PhoneNumber { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; } 
        public DateTime? BirthDate { get; set; }
        public DriverVehicleRequest Vehicle { get; set; }
    }
}