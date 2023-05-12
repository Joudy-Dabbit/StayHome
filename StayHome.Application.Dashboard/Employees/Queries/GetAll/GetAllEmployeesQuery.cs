using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class GetAllEmployeesQuery
{
    public class Request: IRequest<OperationResponse<List<Response>>>
    {
        
    }
    public class Response 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }

        
        public string PhoneNumber { get; set; } 
        public string Email { get; set; } 
        public DateOnly? BirthDate { get;  set; }
        
        public int HandledOrdersCount { get; set; }
        public DateTimeOffset DateCreated { get;  set; }
        public bool IsBlock { get; set; }
        
        
        public static Expression<Func<Employee, Response>> Selector() => u
            => new()
            {
                Id = u.Id,
                FullName = u.FullName,
                ImageUrl = u.ImageUrl,
                Email = u.Email!,
                PhoneNumber = u.PhoneNumber,
                BirthDate = u.BirthDate,
                DateCreated = u.UtcDateCreated,
                HandledOrdersCount = u.Orders.Count(o => !o.UtcDateDeleted.HasValue),
                IsBlock = u.DateBlocked.HasValue
            };
    }
}