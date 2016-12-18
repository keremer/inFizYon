using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using inFizYon;
using inFizYon.Ontology;

namespace inFizYon.Data
{
    public class inFizYonDbContext : DbContext
    {
        public inFizYonDbContext(DbContextOptions<inFizYonDbContext> options)
            : base(options)
        { }
        public DbSet<Phrase> PhraseSet { get; set; }       //Core Model
        public virtual DbSet<Package> PackageSet { get; set; }      //Core Model
        public DbSet<Label> LabelSet { get; set; }        //Autonomous Ontology Model
        public virtual DbSet<Comment> hasCommentSet { get; set; }  //Core Model
        public virtual DbSet<inProject> Projects { get; set; }      //Project Model
        public virtual DbSet<inMF> MFSectionSet { get; set; }       //Semantics Model
        
        //public virtual DbSet<inUF> inUFSet { get; set; }
        //public virtual DbSet<speccheckList> speccheckListSet { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();

            //modelBuilder.Entity<Label>()
            //    .HasKey(i => new { i..phrsID, t.labelID });

            //modelBuilder.Entity<Label>()3
            //    .HasOne(pt => pt.Phrases).WithMany(p => p.)
            //    .Map(l => l.MapLeftKey("LabelID")
            //    .MapRightKey("phrsID")
            //    .ToTable("PhraseLabels"));
        }
    }
}