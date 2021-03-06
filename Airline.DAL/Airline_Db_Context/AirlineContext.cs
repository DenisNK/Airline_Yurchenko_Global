﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Airline.DAL.Configurations;
using Airline.DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace Airline.DAL.Airline_Db_Context
{
    public class AirlineContext : IdentityDbContext
    {
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Navigator> Navigators { get; set; }
        public DbSet<Radio_operator> Radio_Operators { get; set; }
        public DbSet<Team_Person> Team_Persons { get; set; }
        public DbSet<Fligth> Fligths { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FligthTeam> FligthTeams { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Request> Requests { get; set; }

        public AirlineContext(DbContextOptions<AirlineContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new City_Configurations());
            modelBuilder.ApplyConfiguration(new Country_Configurations());
            modelBuilder.ApplyConfiguration(new Navigator_Configurations());
            modelBuilder.ApplyConfiguration(new Pilot_Configurations());
            modelBuilder.ApplyConfiguration(new Stewardess_Configurations());
            modelBuilder.ApplyConfiguration(new Team_Person_Configurations());
            modelBuilder.ApplyConfiguration(new FligthTeam_Configurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RequestConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
