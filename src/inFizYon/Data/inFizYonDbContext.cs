using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using inFizYon;
using inFizYon.Ontology;
using inFizYon.ciqModels;

namespace inFizYon.Data
{
    public class inFizYonDbContext : DbContext
    {
        private readonly IHostingEnvironment env;
        public inFizYonDbContext(IHostingEnvironment env, DbContextOptions<inFizYonDbContext> options)
            : base(options)
        {
            this.env = env;
        }
        public DbSet<Phrase> phraseSet { get; set; }                    //Core Model
        public virtual DbSet<Package> packageSet { get; set; }          //Core Model
        public DbSet<Label> labelSet { get; set; }                      //Autonomous Ontology Model
        public virtual DbSet<PartyReal> peopleSet { get; set; }         //Customer Information Model
        public virtual DbSet<Comment> commentSet { get; set; }          //Core Model
        public virtual DbSet<InProject> projectSet { get; set; }        //Project Model
        public virtual DbSet<InMF> inMFSet { get; set; }                //Semantics Model
        public virtual DbSet<PartyPostalAdress> adressSet { get; set; } //Customer Information Model
        public virtual DbSet<PartyPhone> phoneSet { get; set; }         //Customer Information Model

        //public virtual DbSet<inUF> inUFSet { get; set; }
        //public virtual DbSet<speccheckList> speccheckListSet { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();

            modelBuilder.Entity<PhraseLabel>()
                .HasKey(i => new { i.phrsID, i.labelID });

            modelBuilder.Entity<PhraseLabel>()
                .HasOne(pl => pl.phrase)
                .WithMany(p => p.phraselabels)
                .HasForeignKey(pl => pl.phrsID);

            modelBuilder.Entity<PhraseLabel>()
                .HasOne(pl => pl.label)
                .WithMany(l => l.phraselabels)
                .HasForeignKey(pl => pl.labelID);

            modelBuilder.Entity<Affiliation>()
                .HasKey(a => new { a.ciqPrID, a.ciqPtID });

            modelBuilder.Entity<Affiliation>()
                .HasOne(e => e.employer)
                .WithMany(h => h.humanResources)
                .HasForeignKey(e => e.ciqPrID);

            modelBuilder.Entity<Affiliation>()
                .HasOne(e => e.worker)
                .WithMany(a => a.partyEmployment)
                .HasForeignKey(e => e.ciqPtID);

            modelBuilder.Entity<PhoneOwner>()
                .HasKey(po => new { po.ciqPrID, po.ciqPhoneNrID });

            modelBuilder.Entity<PhoneOwner>()
                .HasOne(p => p.person)
                .WithMany(n => n.phoneNumber)
                .HasForeignKey(p => p.ciqPrID);

            modelBuilder.Entity<PhoneOwner>()
                .HasOne(nr => nr.phoneNumber)
                .WithMany(pt => pt.phoneOwner)
                .HasForeignKey(nr => nr.ciqPhoneNrID);

            modelBuilder.Entity<PartyinAdress>()
                .HasKey(ad => new { ad.ciqPrID, ad.ciqAdresPID });

            modelBuilder.Entity<PartyinAdress>()
                .HasOne(p => p.adressOwner)
                .WithMany(a => a.adressHost)
                .HasForeignKey(p => p.ciqPrID);

            modelBuilder.Entity<PartyinAdress>()
                .HasOne(ad => ad.postalAdress)
                .WithMany(o => o.partyinAdress)
                .HasForeignKey(ad => ad.ciqAdresPID);
        }
    }
}