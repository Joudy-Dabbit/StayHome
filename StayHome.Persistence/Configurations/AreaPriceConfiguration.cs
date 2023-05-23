using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class AreaPriceConfiguration : IEntityTypeConfiguration<AreaPrice>
{
    public void Configure(EntityTypeBuilder<AreaPrice> builder)
    {
        builder.HasOne(areaPrice => areaPrice.Area1)
            .WithMany(area => area.AreaPrices1)
            .HasForeignKey(area => area.Area1Id)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(areaPrice => areaPrice.Area2)
            .WithMany(area => area.AreaPrices2)
            .HasForeignKey(area => area.Area2Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}