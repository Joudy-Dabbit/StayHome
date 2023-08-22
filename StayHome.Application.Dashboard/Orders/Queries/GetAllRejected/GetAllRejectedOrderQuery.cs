using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Orders;

public class GetAllRejectedOrderQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
    }

    public class Response
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DriverId { get; set; }
        public string CancelReason { get; set; }

        public static Expression<Func<Order, Response>> Selector
            => o => new()
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                DriverId = o.DriverId!.Value,
                CancelReason = o.CancelReason
            };
    }
}