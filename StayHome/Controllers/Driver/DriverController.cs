using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Drivers;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Driver;

public class DriverController : ApiController
{
    public DriverController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AllowAnonymous]
    [HttpPost,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LogInDriverCommand.Response))]
    public async Task<IActionResult> LogIn(
        [FromServices] IRequestHandler<LogInDriverCommand.Request, OperationResponse<LogInDriverCommand.Response>> handler,
        [FromBody] LogInDriverCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LogInDriverCommand.Response))]
    public async Task<IActionResult> GetAllVehicleTypes(
        [FromServices] IRequestHandler<GetAllVehicleTypesQuery.Request, 
            OperationResponse<List<GetAllVehicleTypesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [ProducesResponseType(typeof(GetDriverProfileQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyProfile(
        [FromServices] IRequestHandler<GetDriverProfileQuery.Request, OperationResponse<GetDriverProfileQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Driver)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Driver),ApiGroup(ApiGroupNames.Driver)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetDriverProfileQuery.Response))]
    public async Task<IActionResult> Modify(    
        [FromServices] IRequestHandler<ModifyDriverCommand.Request,
            OperationResponse<GetDriverProfileQuery.Response>> handler,
        [FromForm] ModifyDriverCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
}