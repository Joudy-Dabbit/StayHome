using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Settings;

public class GetProfileImagesQuery
{
    public class Request : IRequest<OperationResponse<List<string>>>
    {

    }
}