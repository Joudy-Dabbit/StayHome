using System.Linq.Expressions;
using Domain.Entities;
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
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CityId { get; set; }
        public DateOnly? BirthDate { get; set; }
        public int OrderCount { get; set; }

        public static Expression<Func<Customer, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                Name = c.FullName,
                PhoneNumber = c.PhoneNumber,
                BirthDate = c.BirthDate,
                CityId = c.CityId,
                OrderCount = c.Orders.Count(),
            };
    }
}