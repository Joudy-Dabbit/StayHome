using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class ModifyVehicleHandler : IRequestHandler<ModifyVehicleCommand.Request,
    OperationResponse<GetByIdVehicleQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;

    public ModifyVehicleHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }


    public async Task<OperationResponse<GetByIdVehicleQuery.Response>> HandleAsync(ModifyVehicleCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var vehicle = await _repository.TrackingQuery<Vehicle>()
            .Where(c => c.Id == request.Id)
            .FirstAsync(cancellationToken);

        var imageUrl = await _fileService.Modify(vehicle.ImageUrl, request.ImageFile);
        vehicle.Modify(request.Name, request.VehicleTypeId, request.MaxCapacity,
            request.Color, request.Number, imageUrl);
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(vehicle.Id, GetByIdVehicleQuery.Response.Selector);
    }
}