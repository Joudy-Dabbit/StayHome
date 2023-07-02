using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class BlockDriverCommand
{
    public class Request: IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
    }
}