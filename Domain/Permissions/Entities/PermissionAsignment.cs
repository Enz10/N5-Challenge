using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Permissions.Entities
{
    public class PermissionAssignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PermissionId { get; set; }

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }

        [ForeignKey("PermissionTypeId")]
        public PermissionType PermissionType { get; set; }
    }
}
