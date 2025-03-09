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
    class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(f => f.FirstName)
                       .HasMaxLength(30)
                       .HasColumnName("PassFirstName");

                fullName.Property(f => f.LastName)
                       .HasMaxLength(30)
                       .HasColumnName("PassLastName")
                       .IsRequired();
            });
        }
    }
}
