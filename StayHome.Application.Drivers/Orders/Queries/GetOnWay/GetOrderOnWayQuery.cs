using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Drivers.Orders;

public class GetOrderOnWayQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
    }

    public class Response
    {
        public ShippingOrderRes? ShippingOrder { get; set; }
        public DeliveryOrderRes? DeliveryOrder { get; set; }
        public PassengerOrderRes? PassengerOrder { get; set; }
        
        public class PassengerOrderRes
        {
            public Guid Id { get; set; }
            public string Customer { get; set; }
            public DateTime Date { get; set; }
            public double Coast { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
            public string? Note { get; set; }
            public int NumberOfPassenger { get; set; }    
            public double Distance { get; set; }    
        }
        
        public class ShippingOrderRes
        {
            public Guid Id { get; set; }
            public string Customer { get; set; }
            public DateTime Date { get; set; }
            public double Coast { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
            public string? Note { get; set; }
            public double? Weight { get; set; }    
            public List<ProductsCartMobileDto>? Cart { get; set; } = new();
            public double Distance { get; set; }    
        }
       
        public class DeliveryOrderRes
        {
            public Guid Id { get; set; }
            public string Customer { get; set; }
            public DateTime Date { get; set; }
            public double Coast { get; set; }
            public string Source { get; set; }
            public string Destination { get; set; }
            public string? Note { get; set; }
            public double? Weight { get; set; }    
            public double Distance { get; set; }
            public List<ProductsCartMobileDto>? Cart { get; set; } = new(); 
        }
        
        public static Expression<Func<ShippingOrder, ShippingOrderRes>> ShippingOrderSelector()
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
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime,
                Coast = o.Coast + o.DeliveryCoast,
                Cart = o.Carts.Select(c => new ProductsCartMobileDto()
                {
                    Name = c.Product.Name,
                    Quantity = c.Quantity
                }).ToList(),
                Note = o.Note,
                Weight = o.Weight,
                Distance = 0
            };
        
        public static Expression<Func<DeliveryOrder, DeliveryOrderRes>> DeliveryOrderSelector()
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
                Date = o.ScheduleDate!.HasValue ? o.ScheduleDate.Value : o.UtcDateCreated.DateTime,
                Coast = o.Coast + o.DeliveryCoast,
                Cart = o.Carts.Select(c => new ProductsCartMobileDto()
                {
                    Name = c.Product.Name,
                    Quantity = c.Quantity,
                    ImageUrl = c.Product.ImageUrl
                }).ToList(),
                Note = o.Note,
                Weight = o.Weight,
                Distance = 0
            };
        public static Expression<Func<PassengerOrder, PassengerOrderRes>> PassengerOrderSelector()
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
                Distance = 0
            };
    }
}