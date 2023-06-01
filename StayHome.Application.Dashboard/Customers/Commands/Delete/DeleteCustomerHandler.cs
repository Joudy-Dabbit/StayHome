using Application.Dashboard.Core.Abstractions;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Customers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand.Request, OperationResponse>
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;
    
    public DeleteCustomerHandler(IUserRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResponse> HandleAsync(DeleteCustomerCommand.Request request, CancellationToken cancellationToken = default)
    {
        var toDelete = await _repository.TrackingQuery<Customer>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);

        _repository.SoftDelete(toDelete);
        toDelete.ForEach(customer => _fileService.Delete(customer.ImageUrl));
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}