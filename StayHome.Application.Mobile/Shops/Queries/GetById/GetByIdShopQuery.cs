using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Shops;

public class GetByIdShopQuery
{
    public class Request : IRequest<OperationResponse<Response>>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public TimeSpan? StartTime { get; set; } 
        public TimeSpan? EndTime { get; set; }
        public bool IsOnline { get; set; }
        public List<ProductRes> Products { get; set; }

        public class ProductRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public double Cost { get; set; }
        }


        public static Expression<Func<Shop, Response>> Selector()
            => s => new()
            {
                Id = s.Id,
                Name = s.Name,
                Address = string.Join("-", s.Area.City.Name, s.Area.Name),
                ImageUrl = s.ImageUrl,
                EndTime = s.WorkTimes
                    .FirstOrDefault(w => w.DayOfWeek == DateTime.Now.DayOfWeek)!
                    .EndTime,
                StartTime = s.WorkTimes
                    .FirstOrDefault(w => w.DayOfWeek == DateTime.Now.DayOfWeek)!
                    .StartTime,
               IsOnline = s.WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek &&
                                                (wt.StartTime <= DateTime.Now.TimeOfDay
                                                 && DateTime.Now.TimeOfDay <= wt.EndTime)),
               Products = s.Products.Where(p => p.IsAvailable)
                   .Select(p => new ProductRes()
                   {
                       Id = p.Id,
                       Name = p.Name,
                       ImageUrl = p.ImageUrl,
                       Cost = p.Cost
                   }).ToList()
            };
    }
}