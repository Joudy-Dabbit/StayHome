using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Vehicles;

public class AddVehicleHandler : IRequestHandler<AddVehicleCommand.Request,
    OperationResponse<GetAllVehiclesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;
    private readonly IFileService _fileService;

    public AddVehicleHandler(IStayHomeRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }


    public async Task<OperationResponse<GetAllVehiclesQuery.Response>> HandleAsync(AddVehicleCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var imageUrl = await _fileService.Upload(request.ImageFile);
        var vehicle = new Vehicle(request.Name,
            request.VehicleTypeId, request.MaxCapacity,
            request.Color, request.Number, imageUrl);
        
        _repository.Add(vehicle);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return await _repository.GetAsync(vehicle.Id, GetAllVehiclesQuery.Response.Selector);
    }
}