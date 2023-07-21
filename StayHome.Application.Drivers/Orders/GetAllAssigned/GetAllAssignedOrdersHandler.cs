using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers.Orders;

public class GetAllAssignedOrdersHandler: IRequestHandler<GetAllAssignedOrdersQuery.Request,
    OperationResponse<GetAllAssignedOrdersQuery.Response>>
{
    private readonly IUserRepository _repository;
    private readonly IHttpService _httpService;
    
    public GetAllAssignedOrdersHandler(IUserRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetAllAssignedOrdersQuery.Response>> HandleAsync(GetAllAssignedOrdersQuery.Request request,
        CancellationToken cancellationToken = new())
      => new GetAllAssignedOrdersQuery.Response()
                {
                    PassengerOrder = await _repository.GetAsync(e => 
                            !e.UtcDateDeleted.HasValue && e.DriverId == _httpService.CurrentUserId!.Value,
                        GetAllAssignedOrdersQuery.Response.PassengerOrderSelector()),
                    ShippingOrder = await _repository.GetAsync(e => 
                            !e.UtcDateDeleted.HasValue && e.DriverId == _httpService.CurrentUserId!.Value,
                        GetAllAssignedOrdersQuery.Response.ShippingOrderSelector()),
                    DeliveryOrder = await _repository.GetAsync(e => 
                            !e.UtcDateDeleted.HasValue && e.DriverId == _httpService.CurrentUserId!.Value,
                        GetAllAssignedOrdersQuery.Response.DeliveryOrderSelector()),
                };
}