using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class ModifyDriverHandler : IRequestHandler<ModifyDriverCommand.Request,
    OperationResponse<GetByIdDriverQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public ModifyDriverHandler(IUserRepository userRepository, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<OperationResponse<GetByIdDriverQuery.Response>> HandleAsync(ModifyDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var driver = await _userRepository.TrackingQuery<Driver>()
            .FirstAsync(c => c.Id == request.Id, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Driver>(request.Email, request.Id))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        driver.Modify(request.FullName, request.PhoneNumber,
            request.BirthDate, request.Email );
        
        if (request.Password != null)
        {
            await _userRepository.TryModifyPassword(driver, request.Password);
            await _userManager.UpdateAsync(driver);
        }
        
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _userRepository.GetAsync(driver.Id, 
            GetByIdDriverQuery.Response.Selector());
    }
}