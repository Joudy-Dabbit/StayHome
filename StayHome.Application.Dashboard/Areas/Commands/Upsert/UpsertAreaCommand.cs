using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Areas;

public class UpsertAreaCommand
{
    public class Request : IRequest<OperationResponse<GetAllAreasQuery.Response>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}