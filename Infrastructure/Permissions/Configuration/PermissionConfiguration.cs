using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Permissions.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Domain.Permissions.Entities.Permission>
    {
        public void Configure(EntityTypeBuilder<Domain.Permissions.Entities.Permission> builder)
        {
            builder.Property(p => p.EmployeeName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.EmployeeSurname).IsRequired().HasMaxLength(255);
            builder.Property(p => p.PermissionDate).IsRequired();

            builder.HasOne(p => p.PermissionType)
                .WithMany()
                .HasForeignKey(p => p.PermissionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
