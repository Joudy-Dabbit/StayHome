using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Customers;

public class GetProfileHandler : IRequestHandler<GetProfileQuery.Request,
    OperationResponse<GetProfileQuery.Response>>
{   
    private readonly IHttpService _httpResolverService;
    private readonly IUserRepository _userRepository;

    public GetProfileHandler(IUserRepository userRepository, IHttpService httpResolverService)
    {
        _userRepository = userRepository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<GetProfileQuery.Response>> HandleAsync(GetProfileQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _userRepository.GetAsync( _httpResolverService.CurrentUserId!.Value,
            GetProfileQuery.Response.Selector());
}