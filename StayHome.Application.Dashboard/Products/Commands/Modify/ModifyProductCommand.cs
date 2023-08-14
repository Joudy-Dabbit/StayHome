using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class ModifyProductCommand
{
    public class Request : IRequest<OperationResponse<GetByIdProductQuery.Response>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public double Cost { get; set; }
        public bool IsAvailable { get;  set; }
    }
}