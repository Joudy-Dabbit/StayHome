using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Customers;

public class GetCustomerProfileHandler : IRequestHandler<GetCustomerProfileQuery.Request,
    OperationResponse<GetCustomerProfileQuery.Response>>
{   
    private readonly IHttpService _httpResolverService;
    private readonly IUserRepository _userRepository;

    public GetCustomerProfileHandler(IUserRepository userRepository, IHttpService httpResolverService)
    {
        _userRepository = userRepository;
        _httpResolverService = httpResolverService;
    }

    public async Task<OperationResponse<GetCustomerProfileQuery.Response>> HandleAsync(GetCustomerProfileQuery.Request request,
        CancellationToken cancellationToken = new())
        => await _userRepository.GetAsync( _httpResolverService.CurrentUserId!.Value,
            GetCustomerProfileQuery.Response.Selector());
}