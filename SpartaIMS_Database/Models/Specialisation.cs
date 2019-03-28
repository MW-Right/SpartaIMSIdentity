using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpartaIMS_Database.Models
{
    public class Specialisation
    {
        [Key]
        public int SpecID { get; set; }
        [Display(Name = "Specialisation")]
        public string SpecName { get; set; }

        //Adding foreign key constraints
        public List<Cohort> Cohorts { get; set; }
    }
}
