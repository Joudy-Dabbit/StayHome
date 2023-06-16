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

public sealed class CustomerController : ApiController
{
    public CustomerController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
    [AllowAnonymous]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(LogInCustomerCommand.Response))]
    public async Task<IActionResult> LogIn(
        [FromServices] IRequestHandler<LogInCustomerCommand.Request, OperationResponse<LogInCustomerCommand.Response>> handler,
        [FromQuery] LogInCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    
    [AllowAnonymous]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CreateCustomerCommand.Response))]
    public async Task<IActionResult> Create(    
        [FromServices] IRequestHandler<CreateCustomerCommand.Request,
            OperationResponse<CreateCustomerCommand.Response>> handler,
        [FromQuery] CreateCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfileImages(
        [FromServices] IRequestHandler<GetProfileImagesQuery.Request, OperationResponse<List<string>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(GetProfileQuery.Response), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyProfile(
        [FromServices] IRequestHandler<GetProfileQuery.Request, OperationResponse<GetProfileQuery.Response>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync(); 
    
    #region - Addresses -

    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpGet,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(List<GetMyAddressesQuery.Response>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyAddresses(
        [FromServices] IRequestHandler<GetMyAddressesQuery.Request, OperationResponse<IEnumerable<GetMyAddressesQuery.Response>>> handler)
        => await handler.HandleAsync(new()).ToJsonResultAsync();   
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAddress(
        [FromServices] IRequestHandler<AddCustomerAddressCommand.Request, OperationResponse> handler,
        [FromQuery] AddCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();     
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpPost,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ModifyAddress(
        [FromServices] IRequestHandler<ModifyCustomerAddressCommand.Request, OperationResponse> handler,
        [FromQuery] ModifyCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
    
    
    [AppAuthorize(StayHomeRoles.Customer)]
    [HttpDelete,StayHomeRoute(ApiGroupNames.Mobile),ApiGroup(ApiGroupNames.Mobile)]
    [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAddress(
        [FromServices] IRequestHandler<DeleteCustomerAddressCommand.Request, OperationResponse> handler,
        [FromQuery] DeleteCustomerAddressCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();
    #endregion

}