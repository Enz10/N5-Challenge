using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Permissions.Entities;

namespace Infrastructure.Permissions.Configuration
{
    public class PermissionAssignmentConfiguration : IEntityTypeConfiguration<PermissionAssignment>
    {
        public void Configure(EntityTypeBuilder<PermissionAssignment> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.HasOne(pa => pa.Permission)
                   .WithMany(p => p.PermissionAssignments)
                   .HasForeignKey(pa => pa.PermissionId);

            builder.HasOne(pa => pa.PermissionType)
                   .WithMany(pt => pt.PermissionAssignments)
                   .HasForeignKey(pa => pa.PermissionTypeId);
        }
    }
}
