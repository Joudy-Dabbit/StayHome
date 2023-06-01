using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Cities;

public class DeleteCityHandler : IRequestHandler<DeleteCityCommand.Request,OperationResponse>
{
    private readonly IDeleteRepository _deleteRepository;

    public DeleteCityHandler(IDeleteRepository deleteRepository)
    {
        _deleteRepository = deleteRepository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteCityCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        await _deleteRepository.DeleteCity(request.Ids);
        return OperationResponse.WithOk();
    }
}