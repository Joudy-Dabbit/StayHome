using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Abstractions.Http;

namespace StayHome.Application.Drivers;

public class ModifyDriverHandler: IRequestHandler<ModifyDriverCommand.Request,
    OperationResponse<GetDriverProfileQuery.Response>>
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IHttpService _httpService;
    private readonly IFileService _fileService;

    public ModifyDriverHandler(IUserRepository userRepository, 
        UserManager<User> userManager, IHttpService httpService,
        IFileService fileService)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _httpService = httpService;
        _fileService = fileService;
    }

    public async Task<OperationResponse<GetDriverProfileQuery.Response>> HandleAsync(ModifyDriverCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var driver = await _userRepository.TrackingQuery<Driver>()
            .FirstAsync(c => c.Id == _httpService.CurrentUserId, cancellationToken);
        
        if(await _userRepository.IsEmailExist<Customer>(request.Email, _httpService.CurrentUserId))
            return DomainError.User.EmailAlreadyUsed(request.Email);
        
        var vehicleId = driver.VehicleId;
        if (request.Vehicle is not null)
        {
            var image = await _fileService.Upload(request.Vehicle!.ImageFile);
            var vehicle = new Vehicle(request.Vehicle.Name,
                request.Vehicle.VehicleTypeId, request.Vehicle.MaxCapacity,
                request.Vehicle.Color, request.Vehicle.Number, image);
            _userRepository.Add(vehicle);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            vehicleId = vehicle.Id;
        }
        
        driver.Modify(request.FullName, request.PhoneNumber,
            request.BirthDate, request.Email, vehicleId);

        await _userManager.UpdateAsync(driver);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _userRepository.GetAsync(driver.Id, 
            GetDriverProfileQuery.Response.Selector());
    }
}