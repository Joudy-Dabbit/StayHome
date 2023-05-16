using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class DeleteCustomerAddressHandler
    : IRequestHandler<DeleteCustomerAddressCommand.Request, OperationResponse>
{
    private readonly IUserRepository _repository;

    public DeleteCustomerAddressHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteCustomerAddressCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        var toDelete = await _repository.TrackingQuery<Address>()
            .Where(c => c.Id == request.Id).FirstAsync(cancellationToken);

        _repository.SoftDelete(toDelete);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}