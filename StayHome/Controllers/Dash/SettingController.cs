using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Customers;
using StayHome.Application.Dashboard.Settings;
using StayHome.Util;

namespace StayHome.Controllers.Dash;


public class SettingController : ApiController
{
     public SettingController(IRequestDispatcher dispatcher) : base(dispatcher) { }
    
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCitiesWithAreasQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCitiesWithAreas(
         [FromServices] IRequestHandler<GetAllCitiesWithAreasQuery.Request, 
             OperationResponse<List<GetAllCitiesWithAreasQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();  
}