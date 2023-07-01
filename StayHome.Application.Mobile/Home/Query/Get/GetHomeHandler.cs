using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Home;

public class GetHomeHandler : IRequestHandler<GetHomeQuery.Request,
    OperationResponse<List<GetHomeQuery.Response>>>
{
    private readonly IStayHomeRepository _repository;

    public GetHomeHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<List<GetHomeQuery.Response>>> HandleAsync(GetHomeQuery.Request request,
        CancellationToken cancellationToken = new())
    {
       return await _repository.Query<Shop>()
            .OrderBy(s => s.DeliveryOrders.Count + s.ShippingOrders.Count)
            .Take(4)
            .Select(s => new GetHomeQuery.Response()
            {
                Id = s.Id,
                Name = s.Name,
                Address = string.Join("-", s.Area.City.Name, s.Area.Name),
                // IsOnline = s.WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek &&
                //                                  (wt.StartTime <= DateTime.Now.TimeOfDay
                //                                   && DateTime.Now.TimeOfDay <= wt.EndTime))
            }).ToListAsync(cancellationToken);
    }
}