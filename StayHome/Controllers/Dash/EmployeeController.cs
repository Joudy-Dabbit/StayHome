using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Employees;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Dash;


public class EmployeeController: ApiController
{
    public EmployeeController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AllowAnonymous]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LogInEmployeeCommand.Response))]
    public async Task<IActionResult> LogIn(
        [FromServices] IRequestHandler<LogInEmployeeCommand.Request, OperationResponse<LogInEmployeeCommand.Response>> handler,
        [FromBody] LogInEmployeeCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    

  [AppAuthorize(StayHomeRoles.Employee)]
  [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<GetAllEmployeesQuery.Response>))]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllEmployeesQuery.Request,
            OperationResponse<List<GetAllEmployeesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdEmployeeQuery.Response))]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetByIdEmployeeQuery.Request,
            OperationResponse<GetByIdEmployeeQuery.Response>> handler,
        [FromQuery] GetByIdEmployeeQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    
    [AppAuthorize(StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetAllEmployeesQuery.Response))]
     public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddEmployeeCommand.Request,
            OperationResponse<GetAllEmployeesQuery.Response>> handler,
        [FromForm] AddEmployeeCommand.Request request)  
        => await handler.HandleAsync(request).ToJsonResultAsync();   
     
    [AppAuthorize(StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(GetByIdEmployeeQuery.Response))]
     public async Task<IActionResult> Modify(
        [FromServices] IRequestHandler<ModifyEmployeeCommand.Request,
            OperationResponse<GetByIdEmployeeQuery.Response>> handler,
        [FromForm] ModifyEmployeeCommand.Request request)  
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Admin)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Block(
        [FromServices] IRequestHandler<BlockEmployeeCommand.Request,
            OperationResponse> handler,
        [FromQuery] BlockEmployeeCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Admin)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteEmployeeCommand.Request,
            OperationResponse> handler,
        [FromQuery] Guid? id, [FromBody] List<Guid> ids)
        => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
}