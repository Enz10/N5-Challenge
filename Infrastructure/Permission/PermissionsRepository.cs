using Domain.Permissions;
using Domain.Permissions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Permission
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly PermissionContext databaseContext;

        public PermissionsRepository(PermissionContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Domain.Permissions.Entities.Permission> CreateRequestPermission(Domain.Permissions.Entities.Permission permission, CancellationToken cancellationToken = default)
        {
            var newPermission = await databaseContext.Permissions.AddAsync(permission, cancellationToken);
            await databaseContext.SaveChangesAsync(cancellationToken);
            return newPermission.Entity;
        }

        public async Task<PermissionType> CreateOrUpdatePermissionType(string description, CancellationToken cancellationToken = default)
        {
            var permissionType = await databaseContext.PermissionTypes
                .FirstOrDefaultAsync(pt => pt.Description == description, cancellationToken);

            if (permissionType == null)
            {
                permissionType = new PermissionType { Description = description };
                await databaseContext.PermissionTypes.AddAsync(permissionType, cancellationToken);
            }

            return permissionType;
        }

        public async Task CreatePermissionAssignment(int permissionId, int permissionTypeId, CancellationToken cancellationToken = default)
        {
            var permissionAssignment = new PermissionAssignment
            {
                PermissionId = permissionId,
                PermissionTypeId = permissionTypeId
            };

            await databaseContext.PermissionAssignments.AddAsync(permissionAssignment, cancellationToken);
        }

        public async Task<Domain.Permissions.Entities.Permission> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await databaseContext.Permissions
                .Include(p => p.PermissionType)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public IQueryable<Domain.Permissions.Entities.Permission> GetAllPermissionsQuery()
        {
            return databaseContext.Permissions.Include(p => p.PermissionType);
        }

    }
}
