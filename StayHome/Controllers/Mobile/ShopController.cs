using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Mobile.Shops;
using StayHome.Util;

namespace StayHome.Controllers.Mobile;

public class ShopController : ApiController
{
    public ShopController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(List<GetAllShopsQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllShopsQuery.Request, 
            OperationResponse<List<GetAllShopsQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();   
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(GetByIdShopQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetByIdShopQuery.Request, 
            OperationResponse<GetByIdShopQuery.Response>> handler,
       [FromQuery] GetByIdShopQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync(); 
}