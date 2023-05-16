using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Mobile.Customers;
using StayHome.Util;
using Swashbuckle.AspNetCore.Annotations;

namespace StayHome.Controllers.Mobile;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class CustomerController : ApiController
{
    public CustomerController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AllowAnonymous]
    [HttpPost,ApiGroup(ApiGroupNames.Mobile)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LogInCustomerCommand.Response))]
    public async Task<IActionResult> LogIn(
        [FromServices] IRequestHandler<LogInCustomerCommand.Request, OperationResponse<LogInCustomerCommand.Response>> handler,
        [FromBody] LogInCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [AllowAnonymous]
    [HttpPost,ApiGroup(ApiGroupNames.Mobile)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CreateCustomerCommand.Response))]
    public async Task<IActionResult> Create(    
        [FromServices] IRequestHandler<CreateCustomerCommand.Request,
            OperationResponse<CreateCustomerCommand.Response>> handler,
        [FromBody] CreateCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(GetProfileQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyProfile(
        [FromServices] IRequestHandler<GetProfileQuery.Request, OperationResponse<GetProfileQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync(); 
    
    #region - Addresses -

    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(List<GetMyAddressesQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyAddresses(
        [FromServices] IRequestHandler<GetMyAddressesQuery.Request, OperationResponse<IEnumerable<GetMyAddressesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();   
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse<Guid>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAddress(
        [FromServices] IRequestHandler<AddCustomerAddressCommand.Request, OperationResponse<Guid>> handler,
        [FromBody] AddCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();     
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ModifyAddress(
        [FromServices] IRequestHandler<ModifyCustomerAddressCommand.Request, OperationResponse> handler,
        [FromBody] ModifyCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAddress(
        [FromServices] IRequestHandler<DeleteCustomerAddressCommand.Request, OperationResponse> handler,
        [FromQuery] DeleteCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    #endregion

}