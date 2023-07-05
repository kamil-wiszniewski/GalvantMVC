using GalvantMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = GalvantMVC.Domain.Model.Type;

namespace GalvantMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Compressor> Compressors { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Forklift> Forklifts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Type> Types { get; set; }

        public Context(DbContextOptions options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Equipment>()
                .HasOne(a => a.Forklift).WithOne(b => b.Equipment)
                .HasForeignKey<Forklift>(c => c.EquipmentId);

            builder.Entity<Equipment>()
                .HasOne(a => a.Compressor).WithOne(b => b.Equipment)
                .HasForeignKey<Compressor>(c => c.EquipmentId);

            builder.Entity<Compressor>()
            .Property(c => c.Capacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Compressor>()
            .Property(c => c.Power)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Compressor>()
            .Property(c => c.Pressure)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Forklift>()
            .Property(c => c.LiftingCapacity)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Forklift>()
            .Property(c => c.Speed)
            .HasColumnType("decimal(9,2)");

            builder.Entity<Forklift>()
            .Property(c => c.Weight)
            .HasColumnType("decimal(9,2)");
        }
    }
}
