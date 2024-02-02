using Domain.Permissions.Entities;

namespace Domain.Permissions
{
    public interface IPermissionsRepository
    {
        Task<Permission> CreateRequestPermission(Permission permission, CancellationToken cancellationToken = default);
        Task<PermissionType> CreateOrUpdatePermissionType(string description, CancellationToken cancellationToken = default);
        Task<PermissionType> GetPermissionTypeByPermissionId(int permissionId, CancellationToken cancellationToken);
        Task CreatePermissionAssignment(int permissionId, int permissionTypeId, CancellationToken cancellationToken = default);
        Task<Permission> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<PermissionAssignment>> GetAssignmentsByPermissionId(int permissionId, CancellationToken cancellationToken = default);
        IQueryable<Permission> GetAllPermissionsQuery();
    }
}
