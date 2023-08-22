using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers.Orders;

public class GetAllOrderEvaluatedQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
    }

    public class Response
    {
        public List<OrderRes> ShippingOrder { get; set; }
        public List<OrderRes> DeliveryOrder { get; set; }
        public List<OrderRes> PassengerOrder { get; set; }
        
        public class OrderRes
        {
            public Guid Id { get; set; }
            public string Customer { get; set; }
            public int Star { get; set; }
            public DateTime Date { get; set; }
            public double Coast { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
        }

        public static Expression<Func<ShippingOrder, OrderRes>> ShippingOrderSelector()
            => o => new()
            {
                Id = o.Id,
                Customer = o.Customer.FullName,
                Destination = string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                        o.Destination.Street, o.Destination.Additional),
                Source = o.Source != null ?
                    string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                        o.Source.Street, o.Source.Additional)
                    : string.Join(", ", o.Shop!.Area.City.Name, o.Shop.Area.Name, o.Shop.Name),
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime.AddHours(3),
                Coast = o.Coast + o.DeliveryCoast,
                Star = o.Star!.Value
            }; 
        
        public static Expression<Func<DeliveryOrder, OrderRes>> DeliveryOrderSelector()
            => o => new()
            {
                Id = o.Id,
                Customer = o.Customer.FullName,
                Destination = o.Destination != null ? 
                    string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                        o.Destination.Street, o.Destination.Additional)
                    :  string.Join(", ", o.Shop!.Area.City.Name, o.Shop.Area.Name),
                Source = o.Source != null ?
                    string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                        o.Source.Street, o.Source.Additional)
                    : null,
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime.AddHours(3),
                Coast = o.Coast + o.DeliveryCoast,
                Star = o.Star!.Value
            };     
        
        public static Expression<Func<PassengerOrder, OrderRes>> PassengerOrderSelector()
            => o => new()
            {
                Id = o.Id,
                Customer = o.Customer.FullName,
                Destination = string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                        o.Destination.Street, o.Destination.Additional),
                Source = string.Join(", ", o.Source!.Area.City.Name, o.Source.Area.Name, 
                        o.Source.Street, o.Source.Additional),
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime.AddHours(3),
                Coast = o.DeliveryCoast,
                Star = o.Star!.Value
            };
    }
}