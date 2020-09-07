using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Navigator_Configurations : IEntityTypeConfiguration<Navigator>
    {
        public void Configure(EntityTypeBuilder<Navigator> builder)
        {
            builder.ToTable(NAVIGATOR);

            builder.HasOne(p => p.Team_Person)
                .WithMany(t => t.Navigators)
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
