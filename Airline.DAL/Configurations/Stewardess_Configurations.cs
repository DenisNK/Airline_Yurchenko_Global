using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Stewardess_Configurations : IEntityTypeConfiguration<Stewardess>
    {
        public void Configure(EntityTypeBuilder<Stewardess> builder)
        {
            builder.ToTable(STEWARDESS);

            builder.HasOne(p => p.Team_Person)
                .WithMany(t => t.Stewardesses)
                .HasForeignKey(p => p.Team_PersonId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Age)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
