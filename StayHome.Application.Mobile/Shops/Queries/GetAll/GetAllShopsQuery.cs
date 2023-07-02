using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Shops;

public class GetAllShopsQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public List<ShopRes> Shops { get; set; }

        public class ShopRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string Address { get; set; }
            public TimeSpan? StartTime { get; set; } 
            public TimeSpan? EndTime { get; set; }
            public bool IsOnline { get; set; }
        }

        public static Func<Category, Response> Selector()
            => c => new()
            {
                Id = c.Id,
                Shops = c.Shops.Select(s=> new ShopRes()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = string.Join("-", s.Area.City.Name, s.Area.Name),
                    ImageUrl = s.ImageUrl,
                    EndTime = s.WorkTimes
                        .FirstOrDefault(w => w.DayOfWeek == DateTime.Now.DayOfWeek)
                        ?.EndTime,
                    StartTime = s.WorkTimes
                        .FirstOrDefault(w => w.DayOfWeek == DateTime.Now.DayOfWeek)
                        ?.StartTime,
                    IsOnline = s.WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek &&
                                                     (wt.StartTime <= DateTime.Now.TimeOfDay
                                                      && DateTime.Now.TimeOfDay <= wt.EndTime))
                }).ToList()
            };
    }
}