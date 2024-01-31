using Domain.Permissions;
using Domain.PermissionTypes;

namespace Domain
{
    public interface IUnitOfWork
    {
        IPermissionsRepository PermissionsRepository { get; }
        IPermissionTypesRepository PermissionTypesRepository { get; }
    }
}