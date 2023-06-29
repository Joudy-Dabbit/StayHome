using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class AddDriverHandler : IRequestHandler<AddDriverCommand.Request,
    OperationResponse<GetAllDriversQuery.Response>>
{
    private readonly IUserRepository _userRepository;

    public AddDriverHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    } 
    public async Task<OperationResponse<GetAllDriversQuery.Response>> HandleAsync(AddDriverCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        if(await _userRepository.IsEmailExist<Driver>(request.Email))
            return DomainError.User.EmailAlreadyUsed(request.Email);

        var driver = new Driver(request.FullName,
            request.PhoneNumber, request.BirthDate, request.Email);

        var identityResult = await _userRepository.AddWithRole(driver, StayHomeRoles.Driver, request.Password);
        
        if(!identityResult.Succeeded)
            return identityResult.ToOperationResponse<GetAllDriversQuery.Response>();

        return await _userRepository.GetAsync(driver.Id, GetAllDriversQuery.Response.Selector());    
    }
}