using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class GetProfileQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        
    }
    public class Response
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool? HasAddress { get; set; }
        
        public static Expression<Func<Customer, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                HasAddress = c.Addresses.Any()
            };
    }
}