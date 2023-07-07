using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Home;

public class GetHomeQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Area { get; set; }
        public bool IsOnline { get; set; }
        public static Func<Shop, Response> Selector()
            => s => new Response()
            {
                Id = s.Id,
                Name =  s.Name,
                ImageUrl = s.ImageUrl,
                IsOnline = s.WorkTimes.Any()
                           && s.WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek  &&
                                                    ( wt.StartTime <= DateTime.UtcNow.TimeOfDay 
                                                      && DateTime.UtcNow.TimeOfDay <= wt.EndTime)),
                Area = s.Area.Name
            };
    }
}