using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.DAL.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
          //  builder.ToTable(USER);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
