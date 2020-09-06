using Global_Logic_ASP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Global_Logic_ASP.Core.Initializator.Constants;
namespace Global_Logic_ASP.Core.Configurations
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
