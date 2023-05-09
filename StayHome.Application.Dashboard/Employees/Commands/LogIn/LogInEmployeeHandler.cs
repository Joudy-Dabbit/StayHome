using Domain.Entities;
using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace Application.Dashboard.Employees;

 public class LogInEmployeeHandler : IRequestHandler<LogInEmployeeCommand.Request, 
     OperationResponse<LogInEmployeeCommand.Response>>
 {
     private readonly UserManager<User> _userManager;
     private readonly IUserRepository _userRepository;

     public LogInEmployeeHandler(UserManager<User> userManager, IUserRepository userRepository)
     {
         _userManager = userManager;
         _userRepository = userRepository;
     }


     public async Task<OperationResponse<LogInEmployeeCommand.Response>> HandleAsync(LogInEmployeeCommand.Request query, CancellationToken cancellationToken = new CancellationToken())
     {
         var employee = await _userRepository.Query<Employee>()
                 .FirstOrDefaultAsync(d => d.NormalizedEmail == query.Email.ToUpper(), cancellationToken);

          if (employee == null)
              return DomainError.User.NotFound;
         
          if (!await _userManager.CheckPasswordAsync(employee, query.password))
              return DomainError.User.EmailOrPasswordWrong;
         
          if (employee.DateBlocked.HasValue)
              return DomainError.User.Blocked;
         
          var accessToken = _userRepository.GenerateAccessToken(employee, 
              new List<string>(){StayHomeRoles.Employee.ToString()}, DateTime.UtcNow.AddMinutes(10));
          var refreshToken = await _userRepository.GenerateRefreshToken(employee.Id);
        
          if (!refreshToken.IsSucceded)
              return OperationResponse.WithBadRequest(refreshToken.ErrorMessage).ToResponse<LogInEmployeeCommand.Response>();
          
          return await _userRepository.GetAsync(employee.Id, LogInEmployeeCommand.Response.Selector(accessToken, refreshToken.Token));
     }
}