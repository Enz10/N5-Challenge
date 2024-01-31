using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.PermissionTypes.Entities;

namespace Infrastructure.PermissionTypes.Configuration
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.Property(pt => pt.Description).IsRequired().HasMaxLength(255);
        }
    }
}