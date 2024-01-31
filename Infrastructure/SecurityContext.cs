﻿using Domain.PermissionTypes.Entities;
using Domain.Permissions.Entities;
using Infrastructure.Permissions.Configuration;
using Infrastructure.PermissionTypes.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Infrastructure.PermissionAsignments.Configuration;
using Domain.PermissionAsignments.Entities;

namespace Infrastructure
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

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
