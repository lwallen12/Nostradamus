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

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Edited manually for protection");
        }

        public DbSet<GenericEvent> GenericEvent { get; set; }
        public DbSet<NosterScore> NosterScore { get; set; }
        public DbSet<Noster> Noster { get; set; }
        public DbSet<GenericPrediction> GenericPrediction { get; set; }
        public DbSet<PresidentialPrediction> PresidentialPrediction { get; set; }

    }
}
