using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class ModifyEmployeeHandler : IRequestHandler<ModifyEmployeeCommand.Request,
    OperationResponse<GetByIdEmployeeQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;
    private readonly UserManager<User> _userManager;

    public ModifyEmployeeHandler(IUserRepository userRepository,
        IFileService fileService, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _fileService = fileService;
        _userManager = userManager;
    }

    public async Task<OperationResponse<GetByIdEmployeeQuery.Response>> HandleAsync(ModifyEmployeeCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var employee = await _userRepository.TrackingQuery<Employee>()
            .FirstAsync(c => c.Id == request.Id, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Customer>(request.Email, request.Id))
            return DomainError.User.EmailAlreadyUsed(request.Email);

        var profileImageUrl = employee.ImageUrl;
        if(request.ImageFile != null)
        {
            _fileService.Delete(employee.ImageUrl); 
            profileImageUrl = await _fileService.Upload(request.ImageFile);
        }

        employee.Modify(request.FullName, profileImageUrl!, request.BirthDate,
            request.Email, request.PhoneNumber);
        
        if (request.Password != null)
        {
            await _userRepository.TryModifyPassword(employee, request.Password);
            await _userManager.UpdateAsync(employee);
        }
        
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _userRepository.GetAsync(employee.Id, 
            GetByIdEmployeeQuery.Response.Selector);
    }
}