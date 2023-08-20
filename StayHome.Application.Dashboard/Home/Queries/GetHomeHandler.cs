using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class GetHomeHandler : IRequestHandler<GetHomeQuery.Request,
    OperationResponse<GetHomeQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public GetHomeHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetHomeQuery.Response>> HandleAsync(GetHomeQuery.Request request,
        CancellationToken cancellationToken = default)
        => new GetHomeQuery.Response()
        {
            DriversCount = await _repository.Query<Driver>().CountAsync(cancellationToken: cancellationToken),
            DeliveryOrderCountMonthly = Enumerable.Range(1, 12)
                .GroupJoin(_repository.Query<DeliveryOrder>()
                        .Where(s => s.UtcDateCreated.Year == request.Year)
                        .ToList(),
                    m => m, q => q.UtcDateCreated.Month,
                    (m, q) => q.Count()).ToList(),
            PassengerOrderCountMonthly = Enumerable.Range(1, 12)
                .GroupJoin(_repository.Query<PassengerOrder>()
                        .Where(s => s.UtcDateCreated.Year == request.Year)
                        .ToList(),
                    m => m, q => q.UtcDateCreated.Month,
                    (m, q) => q.Count()).ToList(),
            ShippingOrderCountMonthly = Enumerable.Range(1, 12)
                .GroupJoin(_repository.Query<ShippingOrder>()
                        .Where(s => s.UtcDateCreated.Year == request.Year)
                        .ToList(),
                    m => m, q => q.UtcDateCreated.Month,
                    (m, q) => q.Count()).ToList(),
            EmployeesCount = await _repository.Query<Employee>().CountAsync(cancellationToken: cancellationToken),
            CustomersCount = await _repository.Query<Customer>().CountAsync(cancellationToken: cancellationToken),
            ShopsCount = await _repository.Query<Shop>().CountAsync(cancellationToken: cancellationToken),
            OrdersCount = await _repository.Query<Order>().CountAsync(cancellationToken: cancellationToken),
            BestDrivers = await _repository.Query<Driver>()
                .OrderBy(d => d.Orders.Sum(o => o.Star))
                .Select(d => new GetHomeQuery.Response.HomeInfoRes()
                {
                    Id = d.Id,
                    Name = d.FullName,
                })
                .Take(5).ToListAsync(cancellationToken),
            BestShops = await _repository.Query<Shop>()
                .OrderBy(d => d.ShippingOrders.Count + d.DeliveryOrders.Count)
                .Select(d => new GetHomeQuery.Response.HomeInfoRes()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageUrl = d.ImageUrl
                })
                .Take(5).ToListAsync(cancellationToken),

        };
}

