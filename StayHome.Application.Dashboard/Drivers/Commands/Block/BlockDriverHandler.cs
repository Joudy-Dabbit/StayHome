using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Drivers;

public class BlockDriverHandler : IRequestHandler<BlockDriverCommand.Request, OperationResponse>
{
    private readonly IUserRepository _userRepository;

    public BlockDriverHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResponse> HandleAsync(BlockDriverCommand.Request request, 
        CancellationToken cancellationToken = new())
    {
        var user = await _userRepository.TrackingQuery<Driver>()
            .Where(e => e.Id == request.Id)
            .FirstAsync(cancellationToken);

        await _userRepository.ChangeBlockStatus<Driver>(user.Id);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}