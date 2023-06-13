using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shops;

namespace StayHome.Application.Dashboard.Shops;

public class GetAllSopsQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }
    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public List<WorkTimeDto> WorkTimes { get; set; }
        public bool IsOnline { get; set; }

        public static Expression<Func<Shop, Response>> Selector()
            => s => new Response()
            {
                Id = s.Id,
                Name =  s.Name,
                CategoryId = s.CategoryId,
                ImageUrl = s.ImageUrl,
                WorkTimes = s.WorkTimes.Select(w => new WorkTimeDto()
                {
                    DayOfWeek = w.DayOfWeek,
                    EndTime = w.EndTime,
                    StartTime = w.StartTime
                }).ToList(),
                // IsOnline = s.WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek  &&
                //                                 ( wt.StartTime <= DateTime.Now.TimeOfDay 
                //                                   && DateTime.Now.TimeOfDay <= wt.EndTime))
            };
    }
}

