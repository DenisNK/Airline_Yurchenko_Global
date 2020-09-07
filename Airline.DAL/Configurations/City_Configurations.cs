using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class City_Configurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(CITY);

            builder.HasOne(p => p.Country)
                .WithMany(t => t.Cities)
                .HasForeignKey(p => p.CountryId);

            builder.Property(p => p.Name_City)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.AirportCode)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
