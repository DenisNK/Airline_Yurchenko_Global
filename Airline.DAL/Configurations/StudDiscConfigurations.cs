using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;
namespace Airline.DAL.Configurations
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