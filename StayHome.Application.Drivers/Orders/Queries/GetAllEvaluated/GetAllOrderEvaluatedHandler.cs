using Domain.Enum;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers.Orders;

public class GetAllOrderEvaluatedHandler: IRequestHandler<GetAllOrderEvaluatedQuery.Request,
    OperationResponse<GetAllOrderEvaluatedQuery.Response>>
{
    private readonly IUserRepository _repository;
    private readonly IHttpService _httpService;
    
    public GetAllOrderEvaluatedHandler(IUserRepository repository, IHttpService httpService)
    {
        _repository = repository;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetAllOrderEvaluatedQuery.Response>> HandleAsync(GetAllOrderEvaluatedQuery.Request request,
        CancellationToken cancellationToken = new())
        => new GetAllOrderEvaluatedQuery.Response()
        {
            PassengerOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Star.HasValue,
                GetAllOrderEvaluatedQuery.Response.PassengerOrderSelector()),
            ShippingOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Star.HasValue,
                GetAllOrderEvaluatedQuery.Response.ShippingOrderSelector()),
            DeliveryOrder = await _repository.GetAsync(e => 
                    !e.UtcDateDeleted.HasValue
                    && e.DriverId == _httpService.CurrentUserId!.Value
                    && e.Star.HasValue,
                GetAllOrderEvaluatedQuery.Response.DeliveryOrderSelector()),
        };
}