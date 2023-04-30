using Neptunee.BaseCleanArchitecture.Repository;
using Presentation.Context;

namespace Presentation.Repositories;

public class StayHomeRepository : Repository<Guid, StayHomeDbContext>
{
    public StayHomeRepository(StayHomeDbContext context) : base(context)
    {
    }
}