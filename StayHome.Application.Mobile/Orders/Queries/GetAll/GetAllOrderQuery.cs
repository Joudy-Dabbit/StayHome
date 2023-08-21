using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Orders;

public class GetAllOrderQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
    }

    public class Response
    {
        public Guid Id { get; set; }
        public double Coast { get; set; }
        public string CurrentStage { get; set; }
        public bool CanEvaluate { get; set; }
        public int? Star { get; set; }

        public static Expression<Func<Order, Response>> Selector
            => o => new()
            {
                Id = o.Id,
                Coast =  o.DeliveryCoast,
                CanEvaluate = o.Stages.OrderByDescending(os => os.DateTime)
                    .Any(c => c.CurrentStage == OrderStages.Complete),
                Star = o.Star,
                CurrentStage = o.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage.ToString()
            };
    }
}