using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Permissions.Entities
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        [ForeignKey("PermissionTypeId")]
        public PermissionType PermissionType { get; set; }

        [Required]
        public DateTime PermissionDate { get; set; }

        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
