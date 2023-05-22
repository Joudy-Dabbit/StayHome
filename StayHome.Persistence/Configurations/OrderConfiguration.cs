using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class OrderConfiguration :  IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(x => x.Destination)
            .WithOne(x => x.Order)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(order => order.Destination)
            .WithOne(x => x.Order)
            .OnDelete(DeleteBehavior.Restrict);    }
}