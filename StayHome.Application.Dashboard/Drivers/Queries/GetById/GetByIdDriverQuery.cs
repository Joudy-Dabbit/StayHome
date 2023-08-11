using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;

namespace StayHome.Application.Dashboard.Drivers;

public class GetByIdDriverQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool IsBlock { get; set; }
        public DateTime? BirthDate { get; set; }
        public DriverVehicleResponse Vehicle { get; set; }

        public static Expression<Func<Driver, Response>> Selector() => d
            => new()
            {
                Id = d.Id,
                FullName = d.FullName,
                BirthDate = d.BirthDate,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber,
                IsBlock = d.DateBlocked.HasValue,
                Vehicle = new DriverVehicleResponse()
                {
                    ImageFile = d.Vehicle.ImageUrl,
                    Name = d.Vehicle.Name,
                    Number = d.Vehicle.Number,
                    Color = d.Vehicle.Color,
                    MaxCapacity = d.Vehicle.MaxCapacity,
                    VehicleTypeId = d.Vehicle.VehicleTypeId
                }
            };
    }
}