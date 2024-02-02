using Domain.Permissions.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using static Application.Features.Permissions.Commands.RequestPermission;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class RequestPermission
    {
        public sealed class Handler : IRequestHandler<Command, Permission>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Permission> Handle(Command request, CancellationToken cancellationToken)
            {
                var permissionType = await unitOfWork.PermissionsRepository
                    .CreateOrUpdatePermissionType(request.PermissionTypeDescription, cancellationToken);

                var permission = new Permission
                {
                    EmployeeName = request.EmployeeName,
                    EmployeeSurname = request.EmployeeSurname,
                    PermissionDate = request.PermissionDate,
                };

                var createdPermission = await unitOfWork.PermissionsRepository
                    .CreateRequestPermission(permission, cancellationToken);

                await unitOfWork.PermissionsRepository
                    .CreatePermissionAssignment(createdPermission.Id, permissionType.Id, cancellationToken);

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return createdPermission;
            }

        }
    }
}
