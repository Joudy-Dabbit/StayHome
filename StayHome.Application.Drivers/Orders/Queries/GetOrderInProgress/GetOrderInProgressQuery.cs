using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Drivers.Orders;

public class GetOrderInProgressQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
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
        public double? Weight { get; set; }    
        public List<ProductsCartMobileDto>? Cart { get; set; } = new();

        public static Expression<Func<ShippingOrder, Response>> Selector
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
                Weight = o.Weight
            };
    }
}