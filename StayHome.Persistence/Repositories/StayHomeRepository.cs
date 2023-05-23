using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.Repository;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Repositories;

public class StayHomeRepository : Repository<Guid, StayHomeDbContext>, IStayHomeRepository
{
    public StayHomeRepository(StayHomeDbContext context) : base(context)
    {
    }
}