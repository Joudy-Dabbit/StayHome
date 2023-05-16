using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Customers;

public class GetMyAddressesHandler
    : IRequestHandler<GetMyAddressesQuery.Request, OperationResponse<IEnumerable<GetMyAddressesQuery.Response>>>
{
    private readonly IHttpService _httpResolverService;
    private readonly IUserRepository _repository;

    public GetMyAddressesHandler( IHttpService httpResolverService, IUserRepository repository)
    {
        _httpResolverService = httpResolverService;
        _repository = repository;
    }

    public async Task<OperationResponse<IEnumerable<GetMyAddressesQuery.Response>>> HandleAsync(GetMyAddressesQuery.Request request,
        CancellationToken cancellationToken = new())
        =>  await _repository.GetAsync(a => a.CustomerId ==_httpResolverService.CurrentUserId!.Value ,
            GetMyAddressesQuery.Response.Selector());
    
}