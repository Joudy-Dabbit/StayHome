using Domain.Entities;
using EasyRefreshToken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StayHome.Persistence.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken<User, Guid>>
{
    public void Configure(EntityTypeBuilder<RefreshToken<User, Guid>> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}