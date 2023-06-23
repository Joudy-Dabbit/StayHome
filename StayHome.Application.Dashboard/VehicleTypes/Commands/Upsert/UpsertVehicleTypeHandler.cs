using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.VehicleTypes;

public class UpsertVehicleTypeHandler : IRequestHandler<UpsertVehicleTypeCommand.Request,
    OperationResponse<GetAllVehicleTypesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public UpsertVehicleTypeHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResponse<GetAllVehicleTypesQuery.Response>> HandleAsync(UpsertVehicleTypeCommand.Request request,
        CancellationToken cancellationToken = new ())
    {
        var vehicleType = await _repository.TrackingQuery<VehicleType>()
            .Where(c => request.Id.HasValue && c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (vehicleType is null)
        {
            vehicleType = new VehicleType(request.Name);
            _repository.Add(vehicleType);
        }
        else
        {
            vehicleType.Modify(request.Name);
        }
        
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return await _repository.GetAsync(vehicleType.Id, GetAllVehicleTypesQuery.Response.Selector());
    }
}