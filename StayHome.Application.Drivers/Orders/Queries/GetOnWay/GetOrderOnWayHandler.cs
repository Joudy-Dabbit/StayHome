using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers.Orders;

public class GetOrderOnWayHandler: IRequestHandler<GetOrderOnWayQuery.Request,
    OperationResponse<GetOrderOnWayQuery.Response>>
{
    private readonly IUserRepository _repository;
    private readonly IHttpService _httpService;
    
    public GetOrderOnWayHandler(IUserRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetOrderOnWayQuery.Response>> HandleAsync(GetOrderOnWayQuery.Request request,
        CancellationToken cancellationToken = new())
        => new GetOrderOnWayQuery.Response()
        {
            PassengerOrder = (await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage == OrderStages.OnWay,
                GetOrderOnWayQuery.Response.PassengerOrderSelector())).FirstOrDefault(),
            ShippingOrder = (await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage == OrderStages.OnWay,
                GetOrderOnWayQuery.Response.ShippingOrderSelector())).FirstOrDefault(),
            DeliveryOrder = (await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Stages.OrderByDescending(os => os.DateTime).First().CurrentStage == OrderStages.OnWay,
                GetOrderOnWayQuery.Response.DeliveryOrderSelector())).FirstOrDefault(),
        };
}