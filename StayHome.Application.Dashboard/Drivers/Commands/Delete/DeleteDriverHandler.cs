using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand.Request, OperationResponse>
{
    private readonly IUserRepository _repository;
    
    public DeleteDriverHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteDriverCommand.Request request, 
        CancellationToken cancellationToken = default)
    {
        var toDelete = await _repository.TrackingQuery<Driver>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);

        _repository.SoftDelete(toDelete);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}