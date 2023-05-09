using System.ComponentModel;
using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Employees;

public class ForgetPasswordEmployeeCommand
{
    public class Request : IRequest<OperationResponse>
    {
        [DefaultValue("employee@gmail.com")]
        public string Email { get; set; }
    }
}