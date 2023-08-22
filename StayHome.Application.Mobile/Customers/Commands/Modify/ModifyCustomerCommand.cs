using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;

namespace StayHome.Application.Mobile.Customers;

public class ModifyCustomerCommand
{
    public class Request : IRequest<OperationResponse<GetCustomerProfileQuery.Response>>  
    {
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get;  set; }
    }
}