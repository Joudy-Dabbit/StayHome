// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace StayHome.Persistence.Configurations;
//
// public class AddressOrderConfiguration :  IEntityTypeConfiguration<AddressOrder>
// {
//     public void Configure(EntityTypeBuilder<AddressOrder> builder)
//     {
//         builder.OwnsOne(order => order.AreaId);
//     }
// }