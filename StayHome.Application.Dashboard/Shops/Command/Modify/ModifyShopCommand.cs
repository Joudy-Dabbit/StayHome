using Microsoft.AspNetCore.Http;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Contracts.Shops;

namespace StayHome.Application.Dashboard.Shops;

public class ModifyShopCommand
{
    public class Request : IRequest<OperationResponse<GetByIdShopQuery.Response>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public Guid AreaId { get; set; }
        public Guid CategoryId { get; set; }
        
        public List<WorkTimeReq>? WorkTimes { get; set; }
    }
}