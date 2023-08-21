using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Drivers.Orders;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Driver;

public class OrderController : ApiController
{
    public OrderController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [ProducesResponseType(typeof(GetAllAssignedOrdersQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAssigned(
        [FromServices] IRequestHandler<GetAllAssignedOrdersQuery.Request, 
            OperationResponse<GetAllAssignedOrdersQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync(); 
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [ProducesResponseType(typeof(GetAllDeliveredQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDelivered(
        [FromServices] IRequestHandler<GetAllDeliveredQuery.Request, 
            OperationResponse<GetAllDeliveredQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [ProducesResponseType(typeof(GetOrderOnWayQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrderOnWay(
        [FromServices] IRequestHandler<GetOrderOnWayQuery.Request, 
            OperationResponse<GetOrderOnWayQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [ProducesResponseType(typeof(GetAllOrderEvaluatedQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEvaluated(
        [FromServices] IRequestHandler<GetAllOrderEvaluatedQuery.Request, 
            OperationResponse<GetAllOrderEvaluatedQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdShippingOrderQuery.Response))]
    public async Task<IActionResult> GetByIdShippingOrder(
        [FromServices] IRequestHandler<GetByIdShippingOrderQuery.Request,
            OperationResponse<GetByIdShippingOrderQuery.Response>> handler,
        [FromQuery] GetByIdShippingOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();     
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdDeliveryOrderQuery.Response))]
    public async Task<IActionResult> GetByIdDeliveryOrder(
        [FromServices] IRequestHandler<GetByIdDeliveryOrderQuery.Request,
            OperationResponse<GetByIdDeliveryOrderQuery.Response>> handler,
        [FromQuery] GetByIdDeliveryOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();     
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdPassengerOrderQuery.Response))]
    public async Task<IActionResult> GetByIdPassengerOrder(
        [FromServices] IRequestHandler<GetByIdPassengerOrderQuery.Request,
            OperationResponse<GetByIdPassengerOrderQuery.Response>> handler,
        [FromQuery] GetByIdPassengerOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Accept(
        [FromServices] IRequestHandler<AcceptOrderCommand.Request,
            OperationResponse> handler,
        [FromQuery] AcceptOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();     
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Cancel(
        [FromServices] IRequestHandler<CancelOrderCommand.Request,
            OperationResponse> handler,
        [FromQuery] CancelOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Complete(
        [FromServices] IRequestHandler<CompleteOrderCommand.Request,
            OperationResponse> handler,
        [FromQuery] CompleteOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
}