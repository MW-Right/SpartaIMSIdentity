using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpartaIMS_Database.Models;

namespace SpartaIMS_Database.Data
{
    public class SpartaIMSDbContext : DbContext
    {
        public SpartaIMSDbContext(DbContextOptions<SpartaIMSDbContext> options) : base(options) { }

        public DbSet<SpartanUser> SpartanUsers { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
