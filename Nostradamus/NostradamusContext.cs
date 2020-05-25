﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus
{
    public class NostradamusContext : IdentityDbContext<Noster>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Noster>().ToTable("Noster");

            builder.Entity<NosterRelation>().HasKey(table => new
            {
                table.NosterId,
                table.RelatedNosterId,
                table.CreationDate
            });

            builder.Entity<NosterMessage>().HasKey(table => new
            {
                table.NosterId,
                table.MessageSource,
                table.OriginTime
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=test1.ce8cn9mhhgds.us-east-1.rds.amazonaws.com;Database=Nostradamus;Uid=Wallen;Pwd=MyRDSdb1;Allow User Variables=True;");
        }

        public DbSet<GenericEvent> GenericEvent { get; set; }
        //public DbSet<NosterScore> NosterScore { get; set; }
        public DbSet<Noster> Noster { get; set; }
        public DbSet<GenericPrediction> GenericPrediction { get; set; }
        public DbSet<PresidentialPrediction> PresidentialPrediction { get; set; }
        public DbSet<NosterRelation> NosterRelation { get; set; }
        public DbSet<NosterMessage> NosterMessage { get; set; }

    }
}
