using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class ModifyAreaPriceCommand
{
    public class Request : IRequest<OperationResponse<GetAllAreaPricesQuery.Response>>
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public int TimeBetween { get; set; }
    }
}