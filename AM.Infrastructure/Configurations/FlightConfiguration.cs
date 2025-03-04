using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //builder.HasKey(f => f.FlightId);
            //builder.Property(f => f.AirlineLogo).HasMaxLength(100);
            //builder.Property(f => f.Destination).HasMaxLength(100);
            //builder.Property(f => f.Departure).HasMaxLength(100);
            //builder.Property(f => f.FlightDate).HasColumnType("date");
            //builder.Property(f => f.EffectiveArrival).HasColumnType("date");
            //builder.Property(f => f.EstimateDuration).HasColumnType("int");

            //Configure *-* relationship
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity(t=> t.ToTable("Reservations"));

            //Configure 1-* relationship
            builder.HasOne(f => f.plane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.planeFK)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
