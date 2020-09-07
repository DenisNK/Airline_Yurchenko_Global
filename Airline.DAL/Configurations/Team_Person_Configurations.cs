using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Team_Person_Configurations : IEntityTypeConfiguration<Team_Person>
    {
        public void Configure(EntityTypeBuilder<Team_Person> builder)
        {
            builder.ToTable(TEAM_PERSON);

            //builder.HasOne(p => p.Team_Person)
            //    .WithMany(t => t.Pilots)
            //    .HasForeignKey(p => p.Team_PersonId);

            builder.Property(p => p.Name_Team)
                .IsRequired()
                .HasMaxLength(30);
            
        }
    }
}
