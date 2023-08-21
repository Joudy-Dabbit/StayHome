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
    private readonly IFileService _fileService;

    public AddDriverHandler(IUserRepository userRepository, IFileService fileService)
    {
        _userRepository = userRepository;
        _fileService = fileService;
    } 
    public async Task<OperationResponse<GetAllDriversQuery.Response>> HandleAsync(AddDriverCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        if(await _userRepository.IsEmailExist<Driver>(request.Email))
            return DomainError.User.EmailAlreadyUsed(request.Email);

        var image = await _fileService.Upload(request.Vehicle.ImageFile);
        var vehicle = new Vehicle(request.Vehicle.Name,
            request.Vehicle.VehicleTypeId, request.Vehicle.MaxCapacity,
            request.Vehicle.Color, request.Vehicle.Name, image);
        
        _userRepository.Add(vehicle);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        var driver = new Driver( request.FullName,
            request.PhoneNumber, request.BirthDate, 
            request.Email, vehicle.Id);

        var identityResult = await _userRepository.AddWithRole(driver, StayHomeRoles.Driver, request.Password);
        
        if(!identityResult.Succeeded)
            return identityResult.ToOperationResponse<GetAllDriversQuery.Response>();

        return await _userRepository.GetAsync(driver.Id, GetAllDriversQuery.Response.Selector());    
    }
}