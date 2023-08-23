using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Orders;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllShippingOrderQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
    }

    public class Response
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Destination { get; set; }
        
        public bool IsScheduled { get; set; }
        public bool IsHandled { get; set; }
        public string? Source { get; set; }
        public Guid? ShopId { get; set; }

        
        public static Expression<Func<ShippingOrder, Response>> Selector()
            => o => new()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                Destination = o.Destination != null ? 
                    string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                        o.Destination.Street, o.Destination.Additional)
                     :  string.Join(", ", o.Shop!.Area.City.Name, o.Shop.Area.Name),
                Source = o.Source != null ?
                    string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                    o.Source.Street, o.Source.Additional)
                    : null,
                IsScheduled = o.ScheduleDate.HasValue,
                ShopId = o.ShopId,
                IsHandled = o.Stages.OrderByDescending(os => os.DateTime)
                    .First().CurrentStage != OrderStages.CanselByDriver
                    &&
                     o.Stages.OrderByDescending(os => os.DateTime)
                        .First().CurrentStage != OrderStages.NewOrder
            };
    }
}