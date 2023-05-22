using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class GetByIdEmployeeQuery
{
    public class Request: IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }
    public class Response 
    {
        public Guid Id { get; set; }
        public bool IsBlock { get; set; }
        
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; } 
        public DateTime? BirthDate { get;  set; }

        public static Expression<Func<Employee, Response>> Selector => u
            => new()
            {
                Id = u.Id,
                FullName = u.FullName,
                IsBlock = u.DateBlocked.HasValue,
                ImageUrl = u.ImageUrl,
                Email = u.Email!,
                PhoneNumber = u.PhoneNumber,
                BirthDate = u.BirthDate,
            };

    }
}