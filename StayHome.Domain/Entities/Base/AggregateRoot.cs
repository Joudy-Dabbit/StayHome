using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public class AggregateRoot : AggregateRoot<Guid>
{
    protected AggregateRoot()
    {
        Id = Guid.NewGuid();
    }
}