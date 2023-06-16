using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class ModifyShopCommand
{
    public class Request : IRequest<OperationResponse<GetByIdShopQuery.Response>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Guid AreaId { get; set; }
        public Guid CategoryId { get; set; }
    }
}