using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class BlockEmployeeCommand
{
    public class Request: IRequest<OperationResponse>
    {
        public Guid Id { get; set; }
    }
}