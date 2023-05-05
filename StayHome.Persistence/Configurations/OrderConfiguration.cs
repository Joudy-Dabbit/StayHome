using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class OrderConfiguration :  IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(order => order.Source);
        builder.OwnsOne(order => order.Destination);

    }
}