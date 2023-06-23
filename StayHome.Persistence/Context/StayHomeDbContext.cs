using System.Linq.Expressions;
using System.Reflection;
using Domain.Entities;
using Application.Dashboard.Core.Abstractions;
using EasyRefreshToken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Neptunee.BaseCleanArchitecture.BaseDbContexts;
using Neptunee.BaseCleanArchitecture.BaseDbContexts.Interfaces;
using Neptunee.BaseCleanArchitecture.BaseEntity;
using Neptunee.BaseCleanArchitecture.Clock;
using Neptunee.BaseCleanArchitecture.Dispatchers.DomainEventDispatcher;

namespace StayHome.Persistence.Context;

public class StayHomeDbContext : BaseIdentityDbContext<Guid,User>, IStayHomeDbContext
{
    public StayHomeDbContext(DbContextOptions<StayHomeDbContext> options, IClock clock,
        IDomainEventDispatcher domainEventDispatcher) : 
        base(options, clock, domainEventDispatcher) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        PrimaryKeyValueGenerated(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        var entities = builder.Model
            .GetEntityTypes()
            .Where(e => e.ClrType.BaseType?.Name == typeof(AggregateRoot).Name)
            .Select(e => e.ClrType);

        foreach (var entity in entities)
        {
            Expression<Func<AggregateRoot, bool>> expression = b => !b.UtcDateDeleted.HasValue;
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            builder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
        base.OnModelCreating(builder);
    }
    
    // public static void ConfigureDateDeletedQueryFilter<TKey>(this ModelBuilder builder) where TKey : struct, IEquatable<TKey>
    // {
    //     foreach (var entityType in builder.Model.GetEntityTypes().Where(x =>
    //                  !x.ClrType.IsDefined(typeof(IgnoreAddQueryFilterAttribute))
    //                  && (x.ClrType.BaseType.GetHierarchy().Any(a => a == typeof(BaseEntity<TKey>)) ||
    //                      x.ClrType.GetInterfaces().Any(i => i == typeof(IElIdentity)))))
    //     {
    //         AddQueryFilter<TKey>(builder, f => !f.DateDeleted.HasValue, entityType);
    //     }
    // }
    
    protected void PrimaryKeyValueGenerated(ModelBuilder builder, ValueGenerated valueGenerated = ValueGenerated.Never)
    {
        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty mutableProperty in entityType.GetProperties().Where<IMutableProperty>((Func<IMutableProperty, bool>) (p => p.IsPrimaryKey())))
                mutableProperty.ValueGenerated = valueGenerated;
        }
    } 
    
    
     #region -Security-
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken<User, Guid>> RefreshTokens { get; set; }
    #endregion
        
     #region -Main-
     public DbSet<Area> Areas => Set<Area>();
     public DbSet<City> Cities => Set<City>();
     public DbSet<Product> Products => Set<Product>();
     public DbSet<Category> Categories => Set<Category>();
     public DbSet<ContactUs> ContactsUs => Set<ContactUs>();
     public DbSet<Setting> Settings => Set<Setting>();
     public DbSet<Shop> Shops => Set<Shop>();
     public DbSet<WorkTime>  WorkTimes => Set<WorkTime>();
     public DbSet<Vehicle> Vehicles => Set<Vehicle>();
     public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
     public DbSet<AreaPrice> AreaPrices => Set<AreaPrice>();
     #endregion

     #region -Notification-
     public DbSet<CostumerNotification> CostumerNotifications => Set<CostumerNotification>();
     public DbSet<DashNotification> DashNotifications => Set<DashNotification>();
     public DbSet<DriverNotification> DriverNotifications => Set<DriverNotification>();
     public DbSet<MobileNotification> MobileNotifications => Set<MobileNotification>();
     #endregion

     #region -Order-
        public DbSet<DeliveryOrder> DeliveryOrders => Set<DeliveryOrder>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<PassengerOrder> PassengerOrders => Set<PassengerOrder>();
        public DbSet<ShippingOrder> ShippingOrders => Set<ShippingOrder>();
        #endregion
        
}
