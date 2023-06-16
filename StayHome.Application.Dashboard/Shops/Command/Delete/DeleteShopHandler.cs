using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Shops;

public class DeleteShopHandler : IRequestHandler<DeleteShopCommand.Request,OperationResponse>
{
    private readonly IStayHomeRepository _repository;
    private readonly IDeleteRepository _deleteRepository;
    
    public DeleteShopHandler(IDeleteRepository deleteRepository, IStayHomeRepository repository)
    {
        _deleteRepository = deleteRepository;
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteShopCommand.Request request, CancellationToken cancellationToken = new CancellationToken())
    {
        await _deleteRepository.DeleteShops(request.Ids);
        return OperationResponse.WithOk();
    }
}