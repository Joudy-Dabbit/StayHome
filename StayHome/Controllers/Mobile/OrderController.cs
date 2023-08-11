using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Mobile.Orders;
using StayHome.Util;

namespace StayHome.Controllers.Mobile;

public class OrderController : ApiController
{
    public OrderController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(GetDeliveryCostQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Check(
        [FromServices] IRequestHandler<GetDeliveryCostQuery.Request, OperationResponse<GetDeliveryCostQuery.Response>> handler,
        [FromQuery] GetDeliveryCostQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse<AddShippingOrderCommand.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddShippingOrder(
        [FromServices] IRequestHandler<AddShippingOrderCommand.Request,
            OperationResponse<AddShippingOrderCommand.Response>> handler,
        [FromQuery] AddShippingOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse<AddDeliveryOrderCommand.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddDeliveryOrder(
        [FromServices] IRequestHandler<AddDeliveryOrderCommand.Request, OperationResponse<AddDeliveryOrderCommand.Response>> handler,
        [FromQuery] AddDeliveryOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync(); 
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse<AddPassengerOrderCommand.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddPassengerOrder(
        [FromServices] IRequestHandler<AddPassengerOrderCommand.Request, OperationResponse<AddPassengerOrderCommand.Response>> handler,
        [FromQuery] AddPassengerOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Rate(
        [FromServices] IRequestHandler<RateOrderCommand.Request, OperationResponse> handler,
        [FromQuery] RateOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}