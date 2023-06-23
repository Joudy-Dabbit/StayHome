using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Vehicles;
using StayHome.Util;

namespace StayHome.Controllers.Dash;

public class VehicleController : ApiController
{
    public VehicleController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllVehiclesQuery.Response>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllVehiclesQuery.Request, 
            OperationResponse<List<GetAllVehiclesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdVehicleQuery.Response),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetByIdVehicleQuery.Request, 
            OperationResponse<GetByIdVehicleQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();    
     
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetAllVehiclesQuery.Response),StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddVehicleCommand.Request, 
            OperationResponse<GetAllVehiclesQuery.Response>> handler,
        [FromForm] AddVehicleCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync(); 
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdVehicleQuery.Response),StatusCodes.Status200OK)]
    public async Task<IActionResult> Modify(
        [FromServices] IRequestHandler<ModifyVehicleCommand.Request, 
            OperationResponse<GetByIdVehicleQuery.Response>> handler,
        [FromForm] ModifyVehicleCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteVehicleCommand.Request,
            OperationResponse> handler,
        [FromQuery] Guid? id, [FromBody] List<Guid> ids)
        => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
}