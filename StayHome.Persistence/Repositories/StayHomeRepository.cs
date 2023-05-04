using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Presentation.Context;

namespace StayHome.Presentation.Repositories;

public class StayHomeRepository : Repository<Guid, StayHomeDbContext>
{
    public StayHomeRepository(StayHomeDbContext context) : base(context)
    {
    }
}