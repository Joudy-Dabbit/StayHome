using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Dashboard.Orders;

public class GetByIdShippingOrderQuery
{ 
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }

        public string Destination { get; set; }
        public string? Note { get; private set; }
        
        public DateTime? ScheduleDate { get; set; }
        
        public Guid? ShopId { get; set; }
        public string? Source { get; set; }
        
        public double? Weight { get; set; }
        public List<ProductsCartDto>? Cart { get; set; } = new();
        public double Coast { get; set; }
        public double DeliveryCoast { get; set; }

        public static Expression<Func<ShippingOrder, Response>> Selector
            => o => new()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                Destination = o.Destination != null ? 
                    string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                        o.Destination.Street, o.Destination.Additional)
                    :  string.Join(", ", o.Shop!.Area.City.Name, o.Shop.Area.Name),
                ScheduleDate = o.ScheduleDate,
                Weight = o.Weight,
                Note = o.Note,
                ShopId = o.ShopId,
                Source = o.Source != null ?
                    string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                        o.Source.Street, o.Source.Additional)
                    : null,
                Cart = o.Carts.Select(c => new ProductsCartDto()
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity
                }).ToList(),
                Coast = o.Coast,
                DeliveryCoast = o.DeliveryCoast,
            };
    }
}