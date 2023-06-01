using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities;

public class GetAllCitiesWithAreasQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AreaRes> Areas { get; set; }

        public class AreaRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
        
        public static Expression<Func<City, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                Name = c.Name,
                Areas = c.Areas.Select(a => new AreaRes()
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            };
    }

}