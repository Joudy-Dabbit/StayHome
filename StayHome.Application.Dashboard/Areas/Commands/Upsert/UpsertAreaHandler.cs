using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Areas;

public class UpsertAreaHandler : IRequestHandler<UpsertAreaCommand.Request,
    OperationResponse<GetAllAreasQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public UpsertAreaHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetAllAreasQuery.Response>> HandleAsync(UpsertAreaCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var area = await _repository.TrackingQuery<Area>()
            .Where(c => request.Id.HasValue && c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (area is null)
        {
            area = new Area(request.Name, request.CityId);
            _repository.Add(area);
        }
        else
        {
            area.Modify(request.Name);
        }

        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return await _repository.GetAsync(area.Id, GetAllAreasQuery.Response.Selector());
    }
}