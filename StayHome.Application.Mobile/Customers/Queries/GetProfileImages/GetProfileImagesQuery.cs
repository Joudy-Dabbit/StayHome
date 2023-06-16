using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class GetProfileImagesQuery
{
    public class Request : IRequest<OperationResponse<List<string>>>
    {

    }
}