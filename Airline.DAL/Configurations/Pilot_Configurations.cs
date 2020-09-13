using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    public class Pilot_Configurations : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.ToTable(PILOT);

            builder.HasOne(p => p.Team_Person)
                .WithMany(t => t.Pilots)
                .HasForeignKey(p => p.Team_PersonId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(30);

            builder.Ignore(img => img.ProfileImage);
        }
    }
}
