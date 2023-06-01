using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class GetAllSopsQuery
{
    public class Request : IRequest<List<OperationResponse<Response>>>
    {
        
    }
    public class Response
    {
    }
}

