using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class StayHomeRepository : Repository<Guid, StayHomeDbContext>
{
    public StayHomeRepository(StayHomeDbContext context) : base(context)
    {
    }
}