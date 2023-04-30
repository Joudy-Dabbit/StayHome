using Domain.Entities;
using Domain.Entities.Security;
using Domain.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.Clock;
using Neptunee.BaseCleanArchitecture.Database;
using Neptunee.BaseCleanArchitecture.Dispatchers.DomainEventDispatcher;

namespace Presentation.Context;

public class StayHomeDbContext : BaseIdentityDbContext<Guid,User>, IDbContext
{
    public StayHomeDbContext(DbContextOptions options, IClock clock, IDomainEventDispatcher domainEventDispatcher) : base(options, clock, domainEventDispatcher)
    {
    }
    
    #region -DbSet-
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    #endregion
}