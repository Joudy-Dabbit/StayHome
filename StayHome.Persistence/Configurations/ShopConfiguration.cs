// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace StayHome.Persistence.Configurations;
//
// public class ShopConfiguration : IEntityTypeConfiguration<Shop>
// {
//     public void Configure(EntityTypeBuilder<Shop> builder)
//     {
//         builder.OwnsMany(shop => shop.WorkTimes)
//             .HasOne(x => x.Time);
//         
//         builder.HasMany(x => x.WorkTimes)
//             .WithOne(x => x.Time)
//             .HasForeignKey(x => x.Id)
//             .OnDelete(DeleteBehavior.Restrict);
//     } }