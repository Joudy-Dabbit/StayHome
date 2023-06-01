using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities.Commands.Upsert;

public class UpsertCityHandler : IRequestHandler<UpsertCityCommand.Request,
    OperationResponse<GetAllCitiesQuery.Response>>
{
    private readonly IStayHomeRepository _repository;

    public UpsertCityHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse<GetAllCitiesQuery.Response>> HandleAsync(UpsertCityCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var city = await _repository.TrackingQuery<City>()
            .Where(c => request.Id.HasValue && c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (city is null)
        {
            city = new City(request.Name);
            _repository.Add(city);
        }
        else
        {
            city.Modify(request.Name);
        }

        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return await _repository.GetAsync(city.Id, GetAllCitiesQuery.Response.Selector());
    }
}