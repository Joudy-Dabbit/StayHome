using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class GetAllAreaPricesQuery
{
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
        
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Area1Name { get; set; }
        public string Area2Name { get; set; }
        public double Price { get; set; }

        public static Expression<Func<AreaPrice, Response>> Selector() 
            => ap => new()
            {
                Area1Name = ap.Area1.Name,
                Area2Name = ap.Area2.Name,
                Id = ap.Id,
                Price = ap.Price,
            };
    }
}