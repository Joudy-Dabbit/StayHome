using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class GetByIdCustomerQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid CityId { get; set; }
        public bool IsBlock { get; set; }
        public DateOnly? BirthDate { get; set; }
        public List<AddressRes> Address { get; set; }

        public class AddressRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Guid CityId { get; set; }
            public Guid AreaId { get; set; }
            public string HouseNumber { get; set; }
            public string Street { get; set; }
            public string Floor { get; set; }
            public string? Additional { get; set; }
        }

        public static Expression<Func<Customer, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                CityId = c.CityId,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                IsBlock = c.DateBlocked.HasValue,
                Address = c.Addresses.Where(a => !a.UtcDateDeleted.HasValue)
                    .Select(a => new AddressRes()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        AreaId = a.AreaId,
                        CityId = a.Area.CityId,
                        Additional = a.Additional,
                        Floor = a.Floor,
                        Street = a.Street,
                        HouseNumber = a.HouseNumber
                    }).ToList(),
            };
    }
}