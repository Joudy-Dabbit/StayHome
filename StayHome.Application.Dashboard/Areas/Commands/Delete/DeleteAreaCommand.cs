using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard.Areas;

public class DeleteAreaCommand
{
    public class Request : IRequest<OperationResponse>
    {
        public Request(Guid? id, List<Guid> ids)
        {
            Ids = ids;
            
            if (id.HasValue)
                Ids.Add(id.Value);
        }
        public List<Guid> Ids { get; set; }
    }
}