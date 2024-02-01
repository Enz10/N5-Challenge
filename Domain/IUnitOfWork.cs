using Domain.Permissions;

namespace Domain
{
    public interface IUnitOfWork
    {
        IPermissionsRepository PermissionsRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}