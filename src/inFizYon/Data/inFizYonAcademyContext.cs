using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inFizYon.AcademyModels;
using inFizYon.ciqModels;

namespace inFizYon.Data
{
    public class inFizYonAcademyContext : DbContext
    {
        public inFizYonAcademyContext(DbContextOptions<inFizYonAcademyContext> options) : base(options)     
        { }           
 
        public DbSet<PartyReal> students { get; set; }
        public DbSet<PartyEvaluation> evaluations { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<Criterion> evaluationCriteria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<PartyReal>().ToTable("student");
            modelBuilder.Entity<PartyEvaluation>().ToTable("Evaluation");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<Criterion>().ToTable("Criteria");
        }
    }
}
