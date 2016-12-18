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
 
        public DbSet<PartyReal> Students { get; set; }
        public DbSet<PartyEvaluation> Evaluations { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Criterion> EvaluationCriteria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<PartyReal>().ToTable("Student");
            modelBuilder.Entity<PartyEvaluation>().ToTable("Evaluation");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<Criterion>().ToTable("Criteria");
        }
    }
}
