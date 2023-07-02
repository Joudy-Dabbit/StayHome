using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shops;

namespace StayHome.Application.Dashboard.Shops;

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
        public Guid CategoryId { get; set; }
        public Guid AreaId { get; set; }
        public string ImageUrl { get; set; }
        public List<WorkTimeRes> WorkTimes { get; set; }
        public List<ProductRes> ProductIds { get; set; }
        
        public class ProductRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public double Cost { get; set; }
        }

        public static Expression<Func<Shop, Response>> Selector
            => s => new Response()
            {
                Id = s.Id,
                Name =  s.Name,
                CategoryId = s.CategoryId,
                AreaId = s.AreaId,
                ImageUrl = s.ImageUrl,
                WorkTimes = s.WorkTimes.Select(w => new WorkTimeRes()
                {
                    DayOfWeek = w.DayOfWeek.ToString(),
                    EndTime = w.EndTime,
                    StartTime = w.StartTime
                }).ToList(),
                ProductIds = s.Products.Select(p => new ProductRes()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Cost = p.Cost
                }).ToList()
            };
    }
}