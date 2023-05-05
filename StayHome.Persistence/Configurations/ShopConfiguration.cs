using Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class ShopConfiguration : IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.OwnsMany(order => order.WorkTimes, navigationBuilder =>
        {
            navigationBuilder.ToTable("ShopWorkTimes");
            navigationBuilder.OwnsMany(x => x.Times,
                ownedNavigationBuilder => { ownedNavigationBuilder.ToTable("ShopTimes"); });
        });
    }
}