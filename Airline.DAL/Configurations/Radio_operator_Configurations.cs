using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Radio_operator_Configurations : IEntityTypeConfiguration<Radio_operator>
    {
        public void Configure(EntityTypeBuilder<Radio_operator> builder)
        {
            builder.ToTable(RADIO_OPERATOR);

            builder.HasOne(p => p.Team_Person)
                .WithMany(t => t.Radio_Operators)
                .HasForeignKey(p => p.Team_PersonId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
