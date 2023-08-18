using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shops;

namespace StayHome.Application.Dashboard.Shops;

public class AddShopCommand
{
    public class Request : IRequest<OperationResponse<GetAllSopsQuery.Response>>
    {
        public string Name { get;  set; }
        public IFormFile? ImageFile { get; set; }
    
        public Guid CategoryId { get; set; }
        public Guid AreaId { get; set; }

        public List<WorkTimeReq> WorkTimes { get; set; }
    }
}