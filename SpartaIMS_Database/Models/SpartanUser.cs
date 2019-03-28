using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaIMS_Database.Models
{
    public class SpartanUser
    {
        [Key]
        public int SpartanID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w]+\@spartaglobal\.com$", ErrorMessage = "Email must end with '@spartaglobal.com'")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?!.*\s).{8,30}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter and one number with a minimum of 8 characters.")]
        public string Password { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }

        //Adding foreign key constraints
        public int CohortID { get; set; }
        public Cohort Cohort { get; set; }
        public int JobRoleID { get; set; }
        [Display(Name = "Role")]
        public JobRole JobRole { get; set; }
    }
}
