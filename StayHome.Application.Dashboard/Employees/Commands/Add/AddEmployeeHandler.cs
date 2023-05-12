using Domain.Entities;
using Domain.Enum;
using Domain.Errors;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Files;

namespace StayHome.Application.Dashboard.Employees;

public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand.Request,
    OperationResponse<GetAllEmployeesQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public AddEmployeeHandler(IUserRepository userRepository, IFileService fileService)
    {
        _userRepository = userRepository;
        _fileService = fileService;
    }
    
    public async Task<OperationResponse<GetAllEmployeesQuery.Response>> HandleAsync(AddEmployeeCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        if(await _userRepository.IsEmailExist<Employee>(request.Email))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        var profileImage = await _fileService.Upload(request.ImageFile);
        var employee = new Employee(request.FullName, request.PhoneNumber,
            request.BirthDate, request.Email, profileImage);
        
        var identityResult = await _userRepository.AddWithRole(employee, StayHomeRoles.Employee, request.Password); 
        if(!identityResult.Succeeded)
            return identityResult.ToOperationResponse<GetAllEmployeesQuery.Response>();
        
        return await _userRepository.GetAsync(employee.Id, GetAllEmployeesQuery.Response.Selector());
    }
}