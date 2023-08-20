using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllPassengerOrderQuery
{
    public class Request : IRequest<OperationResponse<Response>>
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

        public static Expression<Func<PassengerOrder, Response>> Selector
            => o => new()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                Destination = string.Join(", ", o.Destination.Area.City.Name, o.Destination.Area.Name, 
                    o.Destination.Street, o.Destination.Additional),
                Source = string.Join(", ", o.Source.Area.City.Name, o.Source.Area.Name, 
                    o.Source.Street, o.Source.Additional),
                IsScheduled = o.ScheduleDate.HasValue,
                IsHandled = o.Stages.OrderByDescending(os => os.DateTime).Any(s => 
                    s.CurrentStage == OrderStages.Confirmed 
                    ||  s.CurrentStage == OrderStages.UnConfirmed)
            };
    }
}