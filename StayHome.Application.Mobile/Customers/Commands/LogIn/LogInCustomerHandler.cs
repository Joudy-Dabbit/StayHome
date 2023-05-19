using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Employees;

namespace StayHome.Application.Mobile.Customers;

public class LogInCustomerHandler : IRequestHandler<LogInCustomerCommand.Request, 
    OperationResponse<LogInCustomerCommand.Response>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _userRepository;

    public LogInCustomerHandler(UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }
    
    public async Task<OperationResponse<LogInCustomerCommand.Response>> HandleAsync(LogInCustomerCommand.Request query, CancellationToken cancellationToken = new CancellationToken())
    {
        var customer = await _userRepository.Query<Customer>()
            .FirstOrDefaultAsync(d => d.NormalizedEmail == query.Email.ToUpper(), cancellationToken);

        if (customer == null)
            return DomainError.User.NotFound;
         
        if (!await _userManager.CheckPasswordAsync(customer, query.password))
            return DomainError.User.EmailOrPasswordWrong;
         
        if (customer.DateBlocked.HasValue)
            return DomainError.User.Blocked;
         
        var accessToken = _userRepository.GenerateAccessToken(customer, 
            new List<string>(){StayHomeRoles.Customer.ToString()});
        var refreshToken = await _userRepository.GenerateRefreshToken(customer.Id);
        
        if (!refreshToken.IsSucceded)
            return OperationResponse.WithBadRequest(refreshToken.ErrorMessage).ToResponse<LogInCustomerCommand.Response>();
          
        return await _userRepository.GetAsync(customer.Id, LogInCustomerCommand.Response.Selector(accessToken, refreshToken.Token));
    }
}