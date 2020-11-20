using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermissionsWebApp.Models
{
    public class PermissionType
    {
        [Key]
        public int Id { get; set; }

        //Identifies the field as required (no nullable)
        [Required(ErrorMessage = "Required Field")]
        //Establishes the field's required length
        [StringLength(50, ErrorMessage = "Field must be between {1} and {2} characters", MinimumLength = 3)]
         public string Description { get; set; }


        public virtual ICollection<Permission> Permissions { get; set; }
    }
}