using Domain.Permissions.Entities;
using Infrastructure.Permissions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PermissionContext : DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options) { }

        public virtual DbSet<Domain.Permissions.Entities.Permission> Permissions { get; set; }
        public virtual DbSet<PermissionAssignment> PermissionAssignments { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionAssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
        }
    }
}
