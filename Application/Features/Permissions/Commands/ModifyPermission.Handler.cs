using Application.Exceptions;
using Domain;
using Domain.Permissions.Entities;
using MediatR;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class ModifyPermission
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
                var permission = await unitOfWork.PermissionsRepository.GetByIdAsync(request.Id, cancellationToken);

                if (permission == null)
                {
                    throw new NotFoundException("Permission not found");
                }

                if (!string.IsNullOrWhiteSpace(request.EmployeeName))
                {
                    permission.EmployeeName = request.EmployeeName;
                }

                if (!string.IsNullOrWhiteSpace(request.EmployeeSurname))
                {
                    permission.EmployeeSurname = request.EmployeeSurname;
                }

                if (request.PermissionDate != DateTime.MinValue)
                {
                    permission.PermissionDate = request.PermissionDate;
                }

                var currentPermissionType = await unitOfWork.PermissionsRepository
                    .GetPermissionTypeByPermissionId(request.Id, cancellationToken);

                if (!string.IsNullOrWhiteSpace(request.PermissionTypeDescription) && currentPermissionType != null)
                {
                    currentPermissionType.Description = request.PermissionTypeDescription;
                }

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return permission;
            }
        }
    }
}
