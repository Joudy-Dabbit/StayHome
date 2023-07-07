using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Drivers;

public class LogInDriverHandler: IRequestHandler<LogInDriverCommand.Request, 
    OperationResponse<LogInDriverCommand.Response>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public LogInDriverHandler(UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    
    public async Task<OperationResponse<LogInDriverCommand.Response>> HandleAsync(LogInDriverCommand.Request query, CancellationToken cancellationToken = new CancellationToken())
    {
        var driver = await _userRepository.Query<Driver>()
            .FirstOrDefaultAsync(d => d.NormalizedEmail == query.Email.ToUpper(), cancellationToken);

        if (driver == null)
            return DomainError.User.NotFound;
         
        if (!await _userManager.CheckPasswordAsync(driver, query.password))
            return DomainError.User.EmailOrPasswordWrong;
         
        if (driver.DateBlocked.HasValue)
            return DomainError.User.Blocked;
         
        var accessToken = _userRepository.GenerateAccessToken(driver, 
            new List<string>(){StayHomeRoles.Driver.ToString()});
        var refreshToken = await _userRepository.GenerateRefreshToken(driver.Id);
        
        if (!refreshToken.IsSucceded)
            return OperationResponse.WithBadRequest(refreshToken.ErrorMessage).ToResponse<LogInDriverCommand.Response>();
          
        return await _userRepository.GetAsync(driver.Id, LogInDriverCommand.Response.Selector(accessToken, refreshToken.Token));
    }
}