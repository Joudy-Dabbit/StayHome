using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Customers;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Dash;

public class CustomerController : ApiController
{
    public CustomerController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetAllCustomerQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
        [FromServices] IRequestHandler<GetAllCustomerQuery.Request, 
            OperationResponse<List<GetAllCustomerQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();    
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdCustomerQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(
        [FromServices] IRequestHandler<GetByIdCustomerQuery.Request, 
            OperationResponse<GetByIdCustomerQuery.Response>> handler,
        [FromQuery] GetByIdCustomerQuery.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  

    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(List<GetCustomerNamesQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetNames(
        [FromServices] IRequestHandler<GetCustomerNamesQuery.Request, 
            OperationResponse<List<GetCustomerNamesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
    
        
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetAllCustomerQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(
        [FromServices] IRequestHandler<AddCustomerCommand.Request,
            OperationResponse<GetAllCustomerQuery.Response>> handler,
        [FromForm] AddCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [ProducesResponseType(typeof(GetByIdCustomerQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> Modify(
        [FromServices] IRequestHandler<ModifyCustomerCommand.Request,
            OperationResponse<GetByIdCustomerQuery.Response>> handler,
        [FromForm] ModifyCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();  
    
    [AppAuthorize(StayHomeRoles.Employee)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(OperationResponse))]
    public async Task<IActionResult> Delete(
        [FromServices] IRequestHandler<DeleteCustomerCommand.Request,
            OperationResponse> handler,
        [FromQuery] Guid? id, [FromBody] List<Guid> ids)
        => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
}