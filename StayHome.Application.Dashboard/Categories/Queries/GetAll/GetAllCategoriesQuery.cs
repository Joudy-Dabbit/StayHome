using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class GetAllCategoriesQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public static Expression<Func<Category, Response>> Selector()
            => c => new()
            {
                Id = c.Id,
                Name = c.Name,
                ImageUrl = c.ImageUrl
            };
    }
}