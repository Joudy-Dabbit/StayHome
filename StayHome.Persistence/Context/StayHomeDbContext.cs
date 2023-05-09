using System.Reflection;
using Domain.Entities;
using Domain.Entities.Main;
using Domain.Entities.Notification;
using Domain.Entities.Orders;
using Domain.Entities.Security;
using Domain.Interfaces.Data;
using EasyRefreshToken.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.BaseDbContexts;
using Neptunee.BaseCleanArchitecture.BaseDbContexts.Interfaces;
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
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
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
     public DbSet<Rate> Rates => Set<Rate>();
     public DbSet<Setting> Settings => Set<Setting>();
     public DbSet<Shop> Shops => Set<Shop>();
     public DbSet<Vehicle> Vehicles => Set<Vehicle>();
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