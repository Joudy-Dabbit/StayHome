using System.ComponentModel;
using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Security;

namespace StayHome.Application.Drivers;

public class LogInDriverCommand
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        [DefaultValue("driver@gmail.com")] public string Email { get; set; }
        [DefaultValue("1234")] public string password { get; set; }
    }
    public class Response : TokenDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DriverVehicleResponse Vehicle { get; set; }

        public static Expression<Func<Driver, Response>> Selector(string accessToken, string refreshToken) 
            => c => new()
            {
                Id = c.Id,
                FullName = c.FullName,
                BirthDate = c.BirthDate,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Vehicle = new DriverVehicleResponse()
                {
                ImageFile = c.Vehicle.ImageUrl,
                Name = c.Vehicle.Name,
                Number = c.Vehicle.Number,
                Color = c.Vehicle.Color,
                MaxCapacity = c.Vehicle.MaxCapacity,
                VehicleTypeId = c.Vehicle.VehicleTypeId
                }
            };
    }
}