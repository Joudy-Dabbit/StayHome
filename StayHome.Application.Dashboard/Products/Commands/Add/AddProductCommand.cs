using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class AddProductCommand
{
    public class Request : IRequest<OperationResponse<GetAllProductsByShopIdQuery.Response>>
    {
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public double Cost { get; set; }
        public Guid ShopId { get; set; }
    }
}