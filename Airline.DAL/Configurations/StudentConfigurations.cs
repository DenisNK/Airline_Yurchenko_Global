using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;
namespace Airline.DAL.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(TABLE_STUDENTS);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(p => p.Group)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
