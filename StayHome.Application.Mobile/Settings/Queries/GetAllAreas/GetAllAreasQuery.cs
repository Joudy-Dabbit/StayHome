using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Settings;

public class GetAllAreasQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }

        public static Expression<Func<Area, Response>> Selector()
            => a => new()
            {
                Id = a.Id,
                Name = a.Name ,
                CityId = a.CityId
            };
    }
}