using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Categories;

public class UpsertCategoryCommand
{
    public class Request : IRequest<OperationResponse<GetAllCategoriesQuery.Response>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}