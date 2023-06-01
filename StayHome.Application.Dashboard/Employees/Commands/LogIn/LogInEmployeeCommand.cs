using System.ComponentModel;
using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;

namespace StayHome.Application.Dashboard.Employees;

public class LogInEmployeeCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        [DefaultValue("admin@gmail.com")] public string Email { get; set; }
        [DefaultValue("1234")] public string password { get; set; }
    }
    
    public class Response : TokenDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        
        public static Expression<Func<Employee, Response>> Selector(string accessToken, string refreshToken)
            => e => new()
            {
                Id = e.Id,
                Email = e.Email,
                RefreshToken = refreshToken,
                AccessToken = accessToken,
            };
    }
}