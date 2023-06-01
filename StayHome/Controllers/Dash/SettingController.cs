using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard.Cities;
using StayHome.Application.Dashboard.Categories;
using StayHome.Application.Dashboard.Cities.Commands.Upsert;
using StayHome.Util;

namespace StayHome.Controllers.Dash;


public class SettingController : ApiController
{
     public SettingController(IRequestDispatcher dispatcher) : base(dispatcher) { }

     #region - Cities -
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCitiesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCities(
         [FromServices] IRequestHandler<GetAllCitiesQuery.Request, 
             OperationResponse<List<GetAllCitiesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();   
     
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCitiesWithAreasQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCitiesWithAreas(
         [FromServices] IRequestHandler<GetAllCitiesWithAreasQuery.Request, 
             OperationResponse<List<GetAllCitiesWithAreasQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();
     
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllCitiesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertCity(
         [FromServices] IRequestHandler<UpsertCityCommand.Request, 
             OperationResponse<GetAllCitiesQuery.Response>> handler,
         [FromBody] UpsertCityCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteCity(
         [FromServices] IRequestHandler<DeleteCityCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion
     
     #region - Categories -
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCategoriesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCategories(
         [FromServices] IRequestHandler<GetAllCategoriesQuery.Request, 
             OperationResponse<List<GetAllCategoriesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();    
     
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllCategoriesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertCategory(
         [FromServices] IRequestHandler<UpsertCategoryCommand.Request, 
             OperationResponse<GetAllCategoriesQuery.Response>> handler,
         [FromBody] UpsertCategoryCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
     [AppAuthorize(StayHomeRoles.Employee)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteCategory(
         [FromServices] IRequestHandler<DeleteCategoryCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion
}