using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers;

public class GetDriverProfileHandler: IRequestHandler<GetDriverProfileQuery.Request,
    OperationResponse<GetDriverProfileQuery.Response>>
{   
    private readonly IHttpService _httpResolverService;
    private readonly IUserRepository _userRepository;

    public GetDriverProfileHandler(IUserRepository userRepository, IHttpService httpResolverService)
    {
        _userRepository = userRepository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<GetDriverProfileQuery.Response>> HandleAsync(GetDriverProfileQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _userRepository.GetAsync( _httpResolverService.CurrentUserId!.Value,
            GetDriverProfileQuery.Response.Selector());
}