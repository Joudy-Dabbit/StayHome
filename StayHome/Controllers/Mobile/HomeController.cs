using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Mobile.Home;
using StayHome.Util;

namespace StayHome.Controllers.Mobile;

public class HomeController: ApiController
{
    public HomeController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(List<GetHomeQuery>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        [FromServices] IRequestHandler<GetHomeQuery.Request,
            OperationResponse<List<GetHomeQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
}