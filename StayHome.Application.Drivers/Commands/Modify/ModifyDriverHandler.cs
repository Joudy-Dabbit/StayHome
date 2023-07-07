using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers;

public class ModifyDriverHandler: IRequestHandler<ModifyDriverCommand.Request,
    OperationResponse<GetDriverProfileQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IHttpService _httpService;

    public ModifyDriverHandler(IUserRepository userRepository, 
        UserManager<User> userManager, IHttpService httpService)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _httpService = httpService;
    }

    public async Task<OperationResponse<GetDriverProfileQuery.Response>> HandleAsync(ModifyDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var driver = await _userRepository.TrackingQuery<Driver>()
            .FirstAsync(c => c.Id == _httpService.CurrentUserId, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Customer>(request.Email, _httpService.CurrentUserId))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        driver.Modify(request.FullName, request.PhoneNumber,
            request.BirthDate, request.Email );

        await _userManager.UpdateAsync(driver);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _userRepository.GetAsync(driver.Id, 
            GetDriverProfileQuery.Response.Selector());
    }
}