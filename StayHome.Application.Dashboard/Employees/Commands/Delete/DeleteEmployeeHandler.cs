using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Repository;
using Neptunee.BaseCleanArchitecture.Requests;
using StayHome.Application.Dashboard.Core.Files;

namespace StayHome.Application.Dashboard.Employees;

public class DeleteEmployeeHandler
    : IRequestHandler<DeleteEmployeeCommand.Request, OperationResponse>
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService ;

    public DeleteEmployeeHandler(IUserRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResponse> HandleAsync(DeleteEmployeeCommand.Request request, CancellationToken cancellationToken = default)
    {
        var employees = await _repository.TrackingQuery<Employee>()
            .Where(c => request.Ids.Contains(c.Id)).ToListAsync(cancellationToken);

        foreach (var employee in employees)
        {
            _fileService.Delete(employee.ImageUrl);
        }
        _repository.SoftDelete(employees);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return OperationResponse.WithOk();
    }
}
