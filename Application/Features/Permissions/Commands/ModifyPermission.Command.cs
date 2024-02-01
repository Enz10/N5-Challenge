using Domain.Permissions.Entities;
using MediatR;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class ModifyPermission
    {
        public sealed class Command : IRequest<Permission>
        {
            public int Id { get; set; }
            public string EmployeeName { get; set; }
            public string EmployeeSurname { get; set; }
            public string PermissionTypeDescription { get; set; }
        }
    }
}
