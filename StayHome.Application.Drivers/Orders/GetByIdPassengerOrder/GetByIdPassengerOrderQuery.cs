using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetByIdPassengerOrderQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public double Coast { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string? Note { get; set; }
        public int NumberOfPassenger { get; set; }    
        public double dest { get; set; }    

        public static Expression<Func<PassengerOrder, Response>> Selector
            => o => new()
            {
                Id = o.Id,
                Customer = o.Customer.FullName,
                Destination = string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                    o.Destination.Street, o.Destination.Additional),
                Source = string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                        o.Source.Street, o.Source.Additional),
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime,
                Coast =  o.DeliveryCoast,
                Note = o.Note,
                NumberOfPassenger = o.NumberOfPassenger,
            };
    }
}