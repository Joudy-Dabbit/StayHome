using Domain.Repositories;
using Neptunee.BaseCleanArchitecture.Repository;
using Presentation.Context;

namespace Presentation.Repositories;

public class UserRepository : StayHomeRepository
{
    public UserRepository(StayHomeDbContext context) : base(context)
    {
    }
}