using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Orders;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Dash;

public class OrderController : ApiController
{
    public OrderController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllShippingOrderQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllShippingOrder(
        [FromServices] IRequestHandler<GetAllShippingOrderQuery.Request, 
            OperationResponse<List<GetAllShippingOrderQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllDeliveryOrderQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllDeliveryOrder(
        [FromServices] IRequestHandler<GetAllDeliveryOrderQuery.Request, 
            OperationResponse<List<GetAllDeliveryOrderQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllPassengerOrderQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPassengerOrder(
        [FromServices] IRequestHandler<GetAllPassengerOrderQuery.Request, 
            OperationResponse<List<GetAllPassengerOrderQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdShippingOrderQuery.Response))]
    public async Task<IActionResult> GetByIdShippingOrder(
        [FromServices] IRequestHandler<GetByIdShippingOrderQuery.Request,
            OperationResponse<GetByIdShippingOrderQuery.Response>> handler,
        [FromQuery] GetByIdShippingOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();       
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdDeliveryOrderQuery.Response))]
    public async Task<IActionResult> GetByIdDeliveryOrder(
        [FromServices] IRequestHandler<GetByIdDeliveryOrderQuery.Request,
            OperationResponse<GetByIdDeliveryOrderQuery.Response>> handler,
        [FromQuery] GetByIdDeliveryOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();      
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdPassengerOrderQuery.Response))]
    public async Task<IActionResult> GetByIdPassengerOrder(
        [FromServices] IRequestHandler<GetByIdPassengerOrderQuery.Request,
            OperationResponse<GetByIdPassengerOrderQuery.Response>> handler,
        [FromQuery] GetByIdPassengerOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdShippingOrderQuery.Response))]
    public async Task<IActionResult> Handle(
        [FromServices] IRequestHandler<HandelOrderCommand.Request,
            OperationResponse> handler,
        [FromBody] HandelOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();      
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteOrderCommand.Request,
            OperationResponse> handler,
        [FromQuery] Guid? id, [FromBody] List<Guid> ids)
        => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Cancel(
        [FromServices] IRequestHandler<CancelOrderCommand.Request,
            OperationResponse> handler,
        [FromQuery] CancelOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}