using Microsoft.EntityFrameworkCore;
using Global_Logic_ASP.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Global_Logic_ASP.Core.Initializator.Constants;
namespace Global_Logic_ASP.Core.Configurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(TABLE_TEACHERS);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
