using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Shops;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

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
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdShopQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetByIdShopQuery.Request, 
            OperationResponse<GetByIdShopQuery.Response>> handler,
        [FromQuery] GetByIdShopQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();

    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetAllSopsQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddShopCommand.Request,
            OperationResponse<GetAllSopsQuery.Response>> handler,
        [FromForm] AddShopCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdShopQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Modify(
        [FromServices] IRequestHandler<ModifyShopCommand.Request,
            OperationResponse<GetByIdShopQuery.Response>> handler,
        [FromForm] ModifyShopCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteShopCommand.Request,
            OperationResponse> handler,
        [FromQuery] Guid? id, [FromBody] List<Guid> ids)
        => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
}