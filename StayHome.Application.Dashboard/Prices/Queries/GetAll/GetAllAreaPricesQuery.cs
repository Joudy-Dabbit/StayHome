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
        public Guid Area1Name { get; set; }
        public Guid Area2Name { get; set; }
        public double Price { get; set; }
        public int KmBetween { get; set; }

        public static Expression<Func<AreaPrice, Response>> Selector() 
            => ap => new()
            {
                Area1Name = ap.Area1.Id,
                Area2Name = ap.Area2.Id,
                Id = ap.Id,
                Price = ap.Price,
                KmBetween = ap.KmBetween
            };
    }
}