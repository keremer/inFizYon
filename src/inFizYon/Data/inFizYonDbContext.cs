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
        public DbSet<Phrase> phraseSet { get; set; }                //Core Model
        public virtual DbSet<Package> packageSet { get; set; }      //Core Model
        public DbSet<Label> LabelSet { get; set; }                  //Autonomous Ontology Model
        public virtual DbSet<Comment> hasCommentSet { get; set; }   //Core Model
        public virtual DbSet<inProject> projects { get; set; }      //Project Model
        public virtual DbSet<inMF> inMFSet { get; set; }            //Semantics Model
        
        //public virtual DbSet<inUF> inUFSet { get; set; }
        //public virtual DbSet<speccheckList> speccheckListSet { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();

            modelBuilder.Entity<PhraseLabel>()
                .HasKey(i => new { i.phrsID, i.labelID });

            modelBuilder.Entity("inFizYon.Ontology.PhraseLabel", b =>
            {
                b.HasOne("inFizYon.Phrase","Phrase")
                    .WithMany("labels")
                    .HasForeignKey("phrsID");

                b.HasOne("inFizYon.Ontology.Label", "Label")
                   .WithMany("phrases")
                   .HasForeignKey("labelID");
            });
        }
    }
}