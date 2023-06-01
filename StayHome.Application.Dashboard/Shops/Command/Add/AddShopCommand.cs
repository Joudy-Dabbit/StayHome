using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class AddShopCommand
{
    public class Request : IRequest<OperationResponse<GetAllSopsQuery.Response>>
    {
        public string Name { get; private set; }
        public string ImageUrl { get; set; }
    
        public Guid CategoryId { get; private set; }
        public Guid AreaId { get; private set; }

    }
}