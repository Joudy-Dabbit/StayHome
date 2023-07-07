using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Mobile.Customers;

public class ModifyCustomerHandler: IRequestHandler<ModifyCustomerCommand.Request,
    OperationResponse<GetProfileQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IHttpService _httpService;

    public ModifyCustomerHandler(IUserRepository userRepository, 
        UserManager<User> userManager, IHttpService httpService)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetProfileQuery.Response>> HandleAsync(ModifyCustomerCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var customer = await _userRepository.TrackingQuery<Customer>()
            .FirstAsync(c => c.Id == _httpService.CurrentUserId, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Customer>(request.Email, _httpService.CurrentUserId))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        customer.Modify(request.FullName, request.BirthDate,
            request.Email, request.CityId,
            request.PhoneNumber, request.Gender);

        await _userManager.UpdateAsync(customer);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _userRepository.GetAsync(customer.Id, 
            GetProfileQuery.Response.Selector());
    }
}