using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Products;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand.Request,OperationResponse>
    {
    private readonly IStayHomeRepository _repository;
    private readonly IDeleteRepository _deleteRepository;

    public DeleteProductHandler(IDeleteRepository deleteRepository, 
        IStayHomeRepository repository)
    {
        _deleteRepository = deleteRepository;
        _repository = repository;
    }

    public async Task<OperationResponse> HandleAsync(DeleteProductCommand.Request request,
        CancellationToken cancellationToken = new())
    {
        await _deleteRepository.DeleteProducts(request.Ids);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return OperationResponse.WithOk();
    }
}