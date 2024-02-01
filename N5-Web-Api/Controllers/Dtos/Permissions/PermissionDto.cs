using Domain.Permissions.Entities;
using Mapster;

namespace N5_Web_Api.Controllers.Dtos.Permissions
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }

        public static void ConfigureMapper(TypeAdapterConfig config)
        {
            config.ForType<Permission, PermissionDto>();
        }
    }

}
