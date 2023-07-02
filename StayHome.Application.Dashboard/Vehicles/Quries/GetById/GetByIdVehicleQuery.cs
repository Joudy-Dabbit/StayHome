using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class GetByIdVehicleQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }    
        public Guid VehicleTypeId { get;  set; }
        public string Color { get; set; }    
        public string Number { get; set; }    
        public double MaxCapacity { get; set; }
        public string ImageUrl { get; set; }

        public static Expression<Func<Vehicle, Response>> Selector
            => c => new()
            {
                Id = c.Id,
                Color = c.Color,
                MaxCapacity = c.MaxCapacity,
                VehicleTypeId = c.VehicleTypeId,
                Number = c.Number,
                ImageUrl = c.ImageUrl
            };
    }
}