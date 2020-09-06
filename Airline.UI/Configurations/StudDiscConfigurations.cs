using Global_Logic_ASP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Global_Logic_ASP.Core.Initializator.Constants;
namespace Global_Logic_ASP.Core.Configurations
{
    public class StudDiscConfigurations : IEntityTypeConfiguration<StudDisc>
    {
        public void Configure(EntityTypeBuilder<StudDisc> builder)
        {
            builder.ToTable(TABLE_STUDDISCS);
            builder.HasKey(e => new { e.DisciplineId, e.StudentId });  //Установим составной первичный ключ
        }
    }
}