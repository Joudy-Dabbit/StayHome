using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers.Orders;

public class GetAllDeliveredHandler: IRequestHandler<GetAllDeliveredQuery.Request,
    OperationResponse<GetAllDeliveredQuery.Response>>
{
    private readonly IUserRepository _repository;
    private readonly IHttpService _httpService;
    
    public GetAllDeliveredHandler(IUserRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetAllDeliveredQuery.Response>> HandleAsync(GetAllDeliveredQuery.Request request,
        CancellationToken cancellationToken = new())
        => new GetAllDeliveredQuery.Response()
        {
            PassengerOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).Any(c => c.CurrentStage == OrderStages.Complete),
                GetAllDeliveredQuery.Response.PassengerOrderSelector()),
            ShippingOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).Any(c => c.CurrentStage == OrderStages.Complete),
                GetAllDeliveredQuery.Response.ShippingOrderSelector()),
            DeliveryOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).Any(c => c.CurrentStage == OrderStages.Complete),
                GetAllDeliveredQuery.Response.DeliveryOrderSelector()),
        };
}