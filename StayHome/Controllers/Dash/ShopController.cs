using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Shops;
using StayHome.Util;

namespace StayHome.Controllers.Dash;

public class ShopController : ApiController
{
    public ShopController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
     [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllSopsQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllSopsQuery.Request, 
            OperationResponse<List<GetAllSopsQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();

    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetAllSopsQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddShopCommand.Request,
            OperationResponse<GetAllSopsQuery.Response>> handler,
        [FromForm] AddShopCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
}