using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Employees;

namespace StayHome.Application.Dashboard.Customers;

public class GetAllCustomerQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {

    }

    public class Response
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CityId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int OrderCount { get; set; }
        public bool IsBlock { get; set; }

        public static Expression<Func<Customer, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                BirthDate = c.BirthDate,
                CityId = c.CityId,
                OrderCount = c.Orders.Count(),
                IsBlock = c.DateBlocked.HasValue
            };
    }
}