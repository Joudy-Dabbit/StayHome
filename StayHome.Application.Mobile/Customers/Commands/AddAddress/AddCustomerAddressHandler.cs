// using Domain.Entities;
// using Domain.Repositories;
// using Microsoft.EntityFrameworkCore;
// using Neptunee.BaseCleanArchitecture.OResponse;
// using Neptunee.BaseCleanArchitecture.Repository;
// using Neptunee.BaseCleanArchitecture.Requests;
// using StayHome.Application.Dashboard.Core.Abstractions.Http;
//
// namespace StayHome.Application.Mobile.Customers;
//
// public class AddCustomerAddressHandler : IRequestHandler<AddCustomerAddressCommand.Request, 
//     OperationResponse>
// {
//     private readonly IHttpService _httpResolverService;
//     private readonly IUserRepository _repository;
//
//     public AddCustomerAddressHandler(IHttpService httpResolverService, IUserRepository repository)
//     {
//         _httpResolverService = httpResolverService;
//         _repository = repository;
//     }
//
//     public async Task<OperationResponse> HandleAsync(AddCustomerAddressCommand.Request request,
//         CancellationToken cancellationToken = new())
//     {
//         var customer = await _repository.TrackingQuery<Customer>()
//             .Where(c => c.Id == _httpResolverService.CurrentUserId!.Value)
//             .Include(c => c.Addresses)
//             .FirstAsync(cancellationToken);
//         
//          customer.AddAddress(request.Name, request.AreaId, 
//             request.HouseNumber, request.Street, request.Additional, request.Floor);
//
//         await  _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
//
//         return OperationResponse.WithOk();
//     }
// }