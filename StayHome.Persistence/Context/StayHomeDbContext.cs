using Domain.Entities;
using Domain.Entities.Security;
using Domain.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Context;

public class StayHomeDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IDbContext
{
    public StayHomeDbContext(DbContextOptions options) : base(options) { }

    #region -DbSet-
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    #endregion

    public new DbSet<TEntity> Set<TEntity>() where TEntity  : class
        => base.Set<TEntity>();
    

    public void Insert<TEntity>(TEntity entity)
        where TEntity : Entity
        => Set<TEntity>().Add(entity);

    public void InsertRange<TEntity>(IReadOnlyCollection<TEntity> entities)
        where TEntity : Entity
        => Set<TEntity>().AddRange(entities);

    public new void Remove<TEntity>(TEntity entity)
        where TEntity : Entity
        => Set<TEntity>().Remove(entity);
}