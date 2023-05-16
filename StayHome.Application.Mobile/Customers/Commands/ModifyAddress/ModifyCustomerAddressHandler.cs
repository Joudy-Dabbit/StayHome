using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Mobile.Customers;

public class ModifyCustomerAddressHandler : IRequestHandler<ModifyCustomerAddressCommand.Request,
    OperationResponse>
{
    private readonly IUserRepository _repository;

    public ModifyCustomerAddressHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(ModifyCustomerAddressCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        var address = await _repository.TrackingQuery<Address>()
            .Where(a => a.Id == request.Id)
            .FirstAsync(cancellationToken);

        address.Modify(request.Name, request.AreaId, 
            request.HouseNumber, request.Street, request.Additional, request.Floor);

        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return OperationResponse.WithOk();
    }
}