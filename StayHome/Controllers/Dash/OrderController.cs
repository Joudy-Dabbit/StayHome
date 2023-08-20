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
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdShippingOrderQuery.Response))]
    public async Task<IActionResult> GetByIdShippingOrder(
        [FromServices] IRequestHandler<GetByIdShippingOrderQuery.Request,
            OperationResponse<GetByIdShippingOrderQuery.Response>> handler,
        [FromQuery] GetByIdShippingOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdShippingOrderQuery.Response))]
    public async Task<IActionResult> Handle(
        [FromServices] IRequestHandler<HandelOrderCommand.Request,
            OperationResponse<GetByIdShippingOrderQuery.Response>> handler,
        [FromBody] HandelOrderCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
}