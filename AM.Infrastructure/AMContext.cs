﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        //DbSet
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=AirportManagementDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        // OnModelCreating (Fluent API) 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1ere méthode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            // modelBuilder.Entity<Passenger>()
            //            .OwnsOne(p => p.FullName);

            //2éme méthode : sans class Configuration
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            //modelBuilder.Entity<Plane>()
            //            .Property(p => p.Capacity)
            //            .HasColumnName("PlaneCapacity");

            //modelBuilder.Entity<Flight>()
            //            .HasMany(f => f.Passengers)
            //            .WithMany(p => p.Flights)
            //            .UsingEntity(j => j.ToTable("Reservations"));
            //modelBuilder.Entity<Flight>()
            //            .HasOne(f => f.plane)
            //            .WithMany(p => p.Flights)
            //            .HasForeignKey(f => f.planeFK)
            //            .IsRequired()
            //            .OnDelete(DeleteBehavior.Cascade);

            // configurer l'heritage Table Per Hierarchy (TPH)
            //modelBuilder.Entity<Passenger>()
            //            .HasDiscriminator<int>("IsTraveller")
            //            .HasValue<Passenger>(2)
            //            .HasValue<Traveller>(1)
            //            .HasValue<Staff>(0);

            // configurer l'heritage Table Per Type (TPT) : juste les classe filles
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            modelBuilder.Entity<Staff>().ToTable("Staffs");


            // configurer la clé primaire de la porteuse de données
            modelBuilder.Entity<Ticket>()
                        .HasKey(t => new { t.FlightFK, t.PassengerFK });

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("datetime");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
