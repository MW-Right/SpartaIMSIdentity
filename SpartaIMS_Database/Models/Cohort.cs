using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaIMS_Database.Models
{
    public class Cohort
    {
        [Key]
        public int CohortID { get; set; }
        [Display(Name = "Cohort Name")]
        public string CohortName { get; set; }
        

        //Adding foreign key constraints
        [Display(Name = "Spartans")]
        public List<SpartanUser> SpartanUsers { get; set; }
        public int SpecID { get; set; }
        public Specialisation Specialisations { get; set; }
       
        
    }
}
