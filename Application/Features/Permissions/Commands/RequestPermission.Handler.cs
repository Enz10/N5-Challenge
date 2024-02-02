using Domain.Permissions.Entities;
using Domain;
using MediatR;
using Nest;
using Application.ElasticSearchEntities;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class RequestPermission
    {
        public sealed class Handler : IRequestHandler<Command, Permission>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IElasticClient elasticClient;

            public Handler(IUnitOfWork unitOfWork, IElasticClient elasticClient)
            {
                this.unitOfWork = unitOfWork;
                this.elasticClient = elasticClient;
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

                var permissionDocument = new PermissionDocument
                {
                    Id = createdPermission.Id,
                    EmployeeName = createdPermission.EmployeeName,
                    EmployeeSurname = createdPermission.EmployeeSurname,
                    PermissionTypeDescription = request.PermissionTypeDescription,
                    PermissionDate = createdPermission.PermissionDate,
                };

                var response = await elasticClient.IndexDocumentAsync(permissionDocument, cancellationToken);
                if (!response.IsValid)
                {
                    throw new System.Exception($"Error al indexar en Elasticsearch: {response.OriginalException.Message}");
                }

                return createdPermission;
            }
        }
    }
}
