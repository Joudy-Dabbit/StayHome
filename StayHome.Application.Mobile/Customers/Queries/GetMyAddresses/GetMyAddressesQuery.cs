using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class GetMyAddressesQuery
{
    public class Request : IRequest<OperationResponse<IEnumerable<Response>>>
    {
    }
    
    public class Response 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; } 
        public string Floor { get; set; } 
        public string? Additional { get; set; }
        
        public static Expression<Func<Address, Response>> Selector() => a
            => new()
            {
                Id = a.Id,
                Name = a.Name,
                Area = a.Area.Name,
                City = a.Area.City.Name,
                Additional = a.Additional,
                HouseNumber = a.HouseNumber,
                Floor = a.Floor,
                Street = a.Street
            };

    }
}