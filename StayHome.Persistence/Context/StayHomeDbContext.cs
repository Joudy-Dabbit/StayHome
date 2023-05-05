using Domain.Entities;
using Domain.Entities.Security;
using Domain.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.BaseDbContexts;
using Neptunee.BaseCleanArchitecture.BaseDbContexts.Interfaces;
using Neptunee.BaseCleanArchitecture.Clock;
using Neptunee.BaseCleanArchitecture.Dispatchers.DomainEventDispatcher;

namespace StayHome.Presentation.Context;

public class StayHomeDbContext : BaseIdentityDbContext<Guid,User>, IStayHomeDbContext
{
    public StayHomeDbContext(DbContextOptions<StayHomeDbContext> options, IClock clock,
        IDomainEventDispatcher domainEventDispatcher) : 
        base(options, clock, domainEventDispatcher)
    {
    }
    
    #region -DbSet-
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    #endregion
}