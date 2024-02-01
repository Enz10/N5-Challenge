using Domain.Permissions.Entities;
using MediatR;

namespace Application.Features.Permissions.Commands
{
    public sealed partial class RequestPermission
    {
        public sealed class Command : IRequest<Permission>
        {
            public string EmployeeName { get; set; }
            public string EmployeeSurname { get; set; }
            public string PermissionTypeDescription { get; set; }
            public DateTime PermissionDate { get; set; }
        }
    }
}
