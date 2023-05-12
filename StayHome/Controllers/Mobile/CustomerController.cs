using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Mobile.Customers.Commands;
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
    [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CreateCustomerCommand.Response))]
    public async Task<IActionResult> Create(    
        [FromServices] IRequestHandler<CreateCustomerCommand.Request,
            OperationResponse<CreateCustomerCommand.Response>> handler,
        [FromBody] CreateCustomerCommand.Request request)
        => await handler.HandleAsync(request).ToJsonResultAsync();   
}