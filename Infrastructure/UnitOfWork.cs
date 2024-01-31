using Domain;
using Domain.PermissionAsignments;
using Domain.Permissions;
using Domain.PermissionTypes;
using Infrastructure.Permission;
using Infrastructure.PermissionAsignments;
using Infrastructure.PermissionTypes;
using MediatR;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SecurityContext securityContext;
        private readonly IMediator mediator;
        private IPermissionsRepository permissionsRepository;
        private IPermissionAsignmentsRepository permissionAsignmentsRepository;
        private IPermissionTypesRepository permissionTypesRepository;

        public UnitOfWork(SecurityContext securityContext, IMediator mediator)
        {
            this.securityContext = securityContext;
            this.mediator = mediator;
        }

        public IPermissionsRepository PermissionsRepository => permissionsRepository ??= new PermissionsRepository(securityContext);
        public IPermissionAsignmentsRepository PermissionAsignmentsRepository => permissionAsignmentsRepository ??= new PermissionAsignmentsRepository(securityContext);
        public IPermissionTypesRepository PermissionTypesRepository => permissionTypesRepository ??= new PermissionsTypesRepository(securityContext);
    }
}