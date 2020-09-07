using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Country_Configurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(COUNTRY);

            builder.Property(p => p.Name_Country)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
