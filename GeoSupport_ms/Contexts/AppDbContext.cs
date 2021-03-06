﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSupport_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoSupport_ms.Contexts
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Country> Country{ get; set; }
        public DbSet<Flag> Flag { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<Color_Flag> Color_Flag { get; set; }
        public DbSet<Place> Place { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color_Flag>()
                .HasKey(x => new { x.Id_color, x.Id_flag });
        }

        

 
    }
}
