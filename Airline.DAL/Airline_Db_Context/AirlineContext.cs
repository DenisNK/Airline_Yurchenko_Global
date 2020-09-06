using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Airline.DAL.Configurations;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace Airline.DAL.Airline_Db_Context
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
            //modelBuilder.ApplyConfiguration(new TeacherConfigurations());
            //modelBuilder.ApplyConfiguration(new StudentConfigurations());
            //modelBuilder.ApplyConfiguration(new StudDiscConfigurations());
            modelBuilder.ApplyConfiguration(new DisciplinesConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
