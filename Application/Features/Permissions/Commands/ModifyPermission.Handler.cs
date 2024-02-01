using Application.Exceptions;
using Domain;
using Domain.Permissions.Entities;
using MediatR;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class ModifyPermission
    {
        public sealed partial class Handler : IRequestHandler<Command, Permission>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Permission> Handle(Command request, CancellationToken cancellationToken)
            {
                var permission = await unitOfWork.PermissionsRepository.GetByIdAsync(request.Id, cancellationToken);

                if (permission == null)
                {
                    throw new NotFoundException("Permission not found");
                }

                permission.EmployeeName = request.EmployeeName;
                permission.EmployeeSurname = request.EmployeeSurname;

                var permissionType = await unitOfWork.PermissionsRepository
                    .CreateOrUpdatePermissionType(request.PermissionTypeDescription, cancellationToken);

                permission.PermissionTypeId = permissionType.Id;

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return permission;
            }
        }
    }
}
