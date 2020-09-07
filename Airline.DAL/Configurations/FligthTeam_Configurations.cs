using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Airline.DAL.Initializator.Constants;

namespace Airline.DAL.Configurations
{
    public class FligthTeam_Configurations : IEntityTypeConfiguration<FligthTeam>
    {
        public void Configure(EntityTypeBuilder<FligthTeam> builder)
        {
            builder.ToTable(FLIGTH_TEAM);
           
            builder.HasKey(e => new {e.Team_PersonId, e.FligthId});  //Установим составной первичный ключ
        }
    }
}
