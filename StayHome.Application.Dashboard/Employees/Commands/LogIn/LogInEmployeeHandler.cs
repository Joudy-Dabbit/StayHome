// using Domain.Entities;
// using Domain.Entities.Security;
// using Domain.Errors;
// using Domain.Repositories;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Neptunee.BaseCleanArchitecture.OResponse;
// using Neptunee.BaseCleanArchitecture.Requests;
//
// namespace Application.Dashboard.Employees;
//
//  public class LogInEmployeeHandler : IRequestHandler<LogInEmployeeCommand.Request, 
//      OperationResponse<LogInEmployeeCommand.Response>>
//  {
//      private readonly UserManager<User> _userManager;
//      private readonly IUserRepository _userRepository;
//
//      public LogInEmployeeHandler(UserManager<User> userManager, IUserRepository userRepository)
//      {
//          _userManager = userManager;
//          _userRepository = userRepository;
//      }
//
//
//      public async Task<OperationResponse<LogInEmployeeCommand.Response>> HandleAsync(LogInEmployeeCommand.Request query, CancellationToken cancellationToken = new CancellationToken())
//      {
//          var user = await _userRepository.Query<Employee>()
//                  .FirstOrDefaultAsync(d => d.NormalizedEmail == query.Email.ToUpper(), cancellationToken);
//
//           if (user == null)
//               return DomainError.User.NotFound;
//          
//           if (!await _userManager.CheckPasswordAsync(user, query.password))
//               return DomainError.User.EmailOrPasswordWrong;
//          
//           if (user.DateBlocked.HasValue)
//               return DomainError.User.Blocked;
//          
//           //var accessToken = await _userRepository.GetAccessToken(user);
//           return await _userRepository.GetAsync(user.Id, LogInEmployeeCommand.Response.Selector("accessToken"));
//      }
// }