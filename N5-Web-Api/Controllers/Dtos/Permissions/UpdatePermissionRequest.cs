using Application.Features.Permissions.Commands;
using Mapster;

namespace N5_Web_Api.Controllers.Dtos.Permissions
{
    public class UpdatePermissionRequest
    {
        public int? Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeSurname { get; set; }
        public string? PermissionTypeDescription { get; set; }
        public DateTime? PermissionDate { get; set; }

        public static void ConfigureMapper(TypeAdapterConfig config)
        {
            config.ForType<UpdatePermissionRequest, ModifyPermission.Command>();
        }
    }
}
