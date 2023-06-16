using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Settings;

public class GetAllCitiesQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<City, Response>> Selector()
            => c => new()
            {
                Id = c.Id,
                Name = c.Name ,
            };
    }
}