using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class DeliveryOrderCartConfiguration : IEntityTypeConfiguration<DeliveryOrderCart>
{
    public void Configure(EntityTypeBuilder<DeliveryOrderCart> builder)
    {
        builder.HasOne(x => x.Order)
            .WithMany(x => x.Carts)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.DeliveryOrderCarts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}