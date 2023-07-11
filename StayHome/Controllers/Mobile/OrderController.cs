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
    [ProducesResponseType(typeof(CheckOrderQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Check(
        [FromServices] IRequestHandler<CheckOrderQuery.Request, OperationResponse<CheckOrderQuery.Response>> handler,
        [FromQuery] CheckOrderQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}