using Global_Logic_ASP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Global_Logic_ASP.Core.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Global_Logic_ASP.Core.DAL
{
    public class AirlineContext : IdentityDbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudDisc> StudDiscs { get; set; }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfigurations());
            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new StudDiscConfigurations());
            modelBuilder.ApplyConfiguration(new DisciplinesConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
