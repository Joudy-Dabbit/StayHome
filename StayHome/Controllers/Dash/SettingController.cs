using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using Neptunee.BaseCleanArchitecture.SwaggerApi.Attributes;
using StayHome.Application.Dashboard;
using StayHome.Application.Dashboard.Areas;
using StayHome.Application.Dashboard.Cities;
using StayHome.Application.Dashboard.Categories;
using StayHome.Application.Dashboard.Cities.Commands.Upsert;
using StayHome.Application.Dashboard.VehicleTypes;
using StayHome.Util;

namespace StayHome.Controllers.Dash;


public class SettingController : ApiController
{
     public SettingController(IRequestDispatcher dispatcher) : base(dispatcher) { }

     #region - Cities -
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCitiesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCities(
         [FromServices] IRequestHandler<GetAllCitiesQuery.Request, 
             OperationResponse<List<GetAllCitiesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();   
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCitiesWithAreasQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCitiesWithAreas(
         [FromServices] IRequestHandler<GetAllCitiesWithAreasQuery.Request, 
             OperationResponse<List<GetAllCitiesWithAreasQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllCitiesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertCity(
         [FromServices] IRequestHandler<UpsertCityCommand.Request, 
             OperationResponse<GetAllCitiesQuery.Response>> handler,
         [FromBody] UpsertCityCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteCity(
         [FromServices] IRequestHandler<DeleteCityCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion    
     
     #region - Areas -
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllAreasQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllAreas(
         [FromServices] IRequestHandler<GetAllAreasQuery.Request, 
             OperationResponse<List<GetAllAreasQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();   
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetNamesAreasQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetNamesAreas(
         [FromServices] IRequestHandler<GetNamesAreasQuery.Request, 
             OperationResponse<List<GetNamesAreasQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllAreasQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertArea(
         [FromServices] IRequestHandler<UpsertAreaCommand.Request, 
             OperationResponse<GetAllAreasQuery.Response>> handler,
         [FromBody] UpsertAreaCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteArea(
         [FromServices] IRequestHandler<DeleteAreaCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion
     
     #region - AreaPrice -
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllAreaPricesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllAreaPrices(
         [FromServices] IRequestHandler<GetAllAreaPricesQuery.Request, 
             OperationResponse<List<GetAllAreaPricesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllAreaPricesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> ModifyAreaPrice(
         [FromServices] IRequestHandler<ModifyAreaPriceCommand.Request, 
             OperationResponse<GetAllAreaPricesQuery.Response>> handler,
         [FromBody] ModifyAreaPriceCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     #endregion

     #region  - Categories -
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllCategoriesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllCategories(
         [FromServices] IRequestHandler<GetAllCategoriesQuery.Request, 
             OperationResponse<List<GetAllCategoriesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();    
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllCategoriesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertCategory(
         [FromServices] IRequestHandler<UpsertCategoryCommand.Request, 
             OperationResponse<GetAllCategoriesQuery.Response>> handler,
         [FromForm] UpsertCategoryCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteCategory(
         [FromServices] IRequestHandler<DeleteCategoryCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion
     
     #region - VehicleTypes -
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpGet,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(List<GetAllVehicleTypesQuery.Response>),StatusCodes.Status200OK)]
     public async Task<IActionResult> GetAllVehicleTypes(
         [FromServices] IRequestHandler<GetAllVehicleTypesQuery.Request, 
             OperationResponse<List<GetAllVehicleTypesQuery.Response>>> handler)
         => await handler.HandleAsync(new()).ToJsonResultAsync();    
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpPost,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(GetAllVehicleTypesQuery.Response),StatusCodes.Status200OK)]
     public async Task<IActionResult> UpsertVehicleType(
         [FromServices] IRequestHandler<UpsertVehicleTypeCommand.Request, 
             OperationResponse<GetAllVehicleTypesQuery.Response>> handler,
         [FromForm] UpsertVehicleTypeCommand.Request request)
         => await handler.HandleAsync(request).ToJsonResultAsync();
     
    [AppAuthorize(StayHomeRoles.Employee, StayHomeRoles.Admin)]
     [HttpDelete,StayHomeRoute(ApiGroupNames.Dashboard),ApiGroup(ApiGroupNames.Dashboard)]
     [ProducesResponseType(typeof(OperationResponse),StatusCodes.Status200OK)]
     public async Task<IActionResult> DeleteVehicleType(
         [FromServices] IRequestHandler<DeleteVehicleTypeCommand.Request,
             OperationResponse> handler,
         [FromQuery] Guid? id, [FromBody] List<Guid> ids)
         => await handler.HandleAsync(new(id, ids)).ToJsonResultAsync();
     #endregion
}