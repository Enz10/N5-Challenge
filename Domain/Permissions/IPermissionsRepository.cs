using Domain.Permissions.Entities;

namespace Domain.Permissions
{
    public interface IPermissionsRepository
    {
        Task<Permission> CreateRequestPermission(Permission permission, CancellationToken cancellationToken = default);
        Task<PermissionType> CreateOrUpdatePermissionType(string description, CancellationToken cancellationToken = default);
        Task CreatePermissionAssignment(int permissionId, int permissionTypeId, CancellationToken cancellationToken = default);
        Task<Permission> GetByIdAsync(int id, CancellationToken cancellationToken);
        IQueryable<Permission> GetAllPermissionsQuery();
    }
}
