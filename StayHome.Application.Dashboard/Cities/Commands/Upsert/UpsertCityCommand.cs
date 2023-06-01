using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities.Commands.Upsert;

public class UpsertCityCommand
{
    public class Request : IRequest<OperationResponse<GetAllCitiesQuery.Response>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}