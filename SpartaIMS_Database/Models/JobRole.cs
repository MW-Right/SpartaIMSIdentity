using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaIMS_Database.Models
{
    public class JobRole
    {
        [Key]
        [Display(Name = "Role ID")]
        public int JobRoleID { get; set; }
        [Display(Name = "Role Name")]
        public string JobRoleName { get; set; }

        //Adding foreign key constraints
        [Display(Name = "Spartans")]
        public List<SpartanUser> SpartanUsers { get; set; }
    }
}
