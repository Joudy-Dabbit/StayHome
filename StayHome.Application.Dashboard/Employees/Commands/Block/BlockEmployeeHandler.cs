using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class BlockEmployeeHandler : IRequestHandler<BlockEmployeeCommand.Request, OperationResponse>
{
    private readonly IUserRepository _userRepository;

    public BlockEmployeeHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse> HandleAsync(BlockEmployeeCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var user = await _userRepository.TrackingQuery<Employee>()
            .Where(e => e.Id == request.Id)
            .FirstAsync(cancellationToken);

        await _userRepository.ChangeBlockStatus<Employee>(user.Id);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}