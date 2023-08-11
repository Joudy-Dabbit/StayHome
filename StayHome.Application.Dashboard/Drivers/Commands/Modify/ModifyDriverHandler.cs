using Application.Dashboard.Core.Abstractions;
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
    private readonly IFileService _fileService;

    public ModifyDriverHandler(IUserRepository userRepository,
        UserManager<User> userManager, IFileService fileService)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _fileService = fileService;
    }

    public async Task<OperationResponse<GetByIdDriverQuery.Response>> HandleAsync(ModifyDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var driver = await _userRepository.TrackingQuery<Driver>()
            .FirstAsync(c => c.Id == request.Id, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Driver>(request.Email, request.Id))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        var vehicleId = driver.VehicleId;
        if (request.Vehicle is not null)
        {
            var image = await _fileService.Upload(request.Vehicle!.ImageFile);
            var vehicle = new Vehicle(request.Vehicle.Name,
                request.Vehicle.VehicleTypeId, request.Vehicle.MaxCapacity,
                request.Vehicle.Color, request.Vehicle.Name, image);
            _userRepository.Add(vehicle);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            vehicleId = vehicle.Id;
        }
        
        driver.Modify(request.FullName, request.PhoneNumber,
            request.BirthDate, request.Email, vehicleId);
        
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