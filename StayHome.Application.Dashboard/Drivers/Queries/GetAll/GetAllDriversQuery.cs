using System.Linq.Expressions;
using Domain.Entities;
using Domain.Enum;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetAllDriversQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {

    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? BirthDate { get; set; }
        public int OrderCount { get; set; }

        public static Expression<Func<Driver, Response>> Selector() => d
            => new()
            {
                Id = d.Id,
                Name = d.FullName,
                PhoneNumber = d.PhoneNumber,
                BirthDate = d.BirthDate,
                OrderCount = d.Orders.Count(),
                IsAvailable = d.Orders.Any(o => o.Stages
                                                      .OrderByDescending(os => os.DateTime)
                                                      .First().CurrentStage == OrderStages.OnWay)
            };
    }
}