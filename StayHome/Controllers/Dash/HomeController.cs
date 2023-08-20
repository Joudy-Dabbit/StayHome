using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard;
using StayHome.Util;

namespace StayHome.Controllers.Dash;

public class HomeController: ApiController
{
    public HomeController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    // [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetHomeQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetHomeQuery.Request, 
            OperationResponse<GetHomeQuery.Response>> handler,
        [FromQuery] GetHomeQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}