using Domain.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Permissions.ElasticSearchEntities
{
    public class PermissionDocument
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionTypeDescription { get; set; }
        public DateTime PermissionDate { get; set; }

        public PermissionDocument(Permission permission)
        {
            Id = permission.Id;
            EmployeeName = permission.EmployeeName;
            EmployeeSurname = permission.EmployeeSurname;
            PermissionTypeId = permission.PermissionTypeId;
            PermissionTypeDescription = permission.PermissionType.Description;
            PermissionDate = permission.PermissionDate;
        }
    }

}
