using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shops;

namespace StayHome.Application.Dashboard.Products;

public class GetAllProductsByShopIdQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        public Guid ShopId { get; set; }
    }
    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Cost { get; set; }
        
        public static Expression<Func<Product, Response>> Selector()
            => s => new Response()
            {
                Id = s.Id,
                Name =  s.Name,
                ImageUrl = s.ImageUrl,
                Cost = s.Cost
            };
    }
}