using System.Linq.Expressions;
using Domain.Entities;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class GetDriverNamesQuery
{ 
    public class Request : IRequest<OperationResponse<List<Response>>>
    {
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public static Expression<Func<Driver, Response>> Selector() => c
            => new()
            {
                Id = c.Id,
                FullName = c.FullName
            };
    }

}