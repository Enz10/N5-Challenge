using Domain;
using Domain.Permissions;
using Infrastructure.Permission;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PermissionContext permissionContext;
        private readonly IMediator mediator;
        private IPermissionsRepository permissionsRepository;

        public UnitOfWork(PermissionContext securityContext, IMediator mediator)
        {
            this.permissionContext = securityContext;
            this.mediator = mediator;
        }

        public IPermissionsRepository PermissionsRepository => permissionsRepository ??= new PermissionsRepository(permissionContext);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await permissionContext.SaveChangesAsync(cancellationToken);
        }
    }
}