using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public DateTime PermissionDate { get; set; }

        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
