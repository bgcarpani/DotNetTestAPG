using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PermissionsWebApp.Models
{
    public class Permission
    {
        //DataAnnotations
        //Identifies the field as the primary Key
        [Key] 
        public int Id { get; set; }

        //Identifies the field as required (no nullable)
        [Required(ErrorMessage = "Required Field")] 
        //Establishes the field's required length
        [StringLength(50, ErrorMessage = "Field must be between {1} and {2} characters", MinimumLength = 3)] 
        //Establishes the display name of the field
        [Display(Name = "Employee Name")]
        public string EmployeeFirstName { get; set; }

        //Identifies the field as required (no nullable)
        [Required(ErrorMessage = "Required Field")]
        //Establishes the field's required length
        [StringLength(50, ErrorMessage = "Field must be between {1} and {2} characters", MinimumLength = 3)]
        //Establishes the display name of the field
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }


        //Identifies the field as required (no nullable)
        [Required(ErrorMessage = "Required field")]
        //Establishes the display name of the field
        [Display(Name = "Permission Type")]
        public int PermissionTypeId { get; set; }


        //Identifies the field as required (no nullable)
        [Required(ErrorMessage = "Required field")]
        //Establishes that the field's value type is dateTime
        [DataType(DataType.DateTime)]
        //Establishes the display name of the field
        [Display(Name = "Permission Date")]
        public DateTime PermissionDate { get; set; }

        public virtual PermissionType PermissionType { get; set; }
    }
}