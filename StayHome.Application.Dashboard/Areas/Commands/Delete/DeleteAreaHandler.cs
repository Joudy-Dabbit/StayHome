using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Areas;

public class DeleteAreaHandler: IRequestHandler<DeleteAreaCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;

    public DeleteAreaHandler(IStayHomeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteAreaCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDelete = await _repository.TrackingQuery<Area>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);
        _repository.SoftDelete(toDelete);
        return OperationResponse.WithOk();
    }
}