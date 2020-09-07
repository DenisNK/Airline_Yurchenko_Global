using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    class Fligth_Configurations : IEntityTypeConfiguration<Fligth>
    {
        public void Configure(EntityTypeBuilder<Fligth> builder)
        {
            builder.ToTable(FLIGTH);

            //builder.HasOne(p => p.Team_Person)
            //    .WithMany(t => t.Fligths)
            //    .HasForeignKey(p => p.TeamPersonId);

            builder.Property(p => p.Name_Fligth)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Price)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
