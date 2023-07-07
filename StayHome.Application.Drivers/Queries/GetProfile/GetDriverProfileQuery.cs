using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers;

public class GetDriverProfileQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        
    }
    public class Response
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public static Expression<Func<Driver, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
            };
    }
}