using Domain.PermissionAsignments.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.PermissionAsignments.Configuration
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
