using Domain.Entities;
using Domain.Entities.Security;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace Application.Dashboard.Employees;

public class LogInEmployeeHandler : IRequestHandler<LogInEmployeeCommand.Request, OperationResponse<LogInEmployeeCommand.Response>>
{
    private readonly UserManager<User> _userManager;

    public LogInEmployeeHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    public Task<OperationResponse<LogInEmployeeCommand.Response>> HandleAsync(LogInEmployeeCommand.Request query, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}