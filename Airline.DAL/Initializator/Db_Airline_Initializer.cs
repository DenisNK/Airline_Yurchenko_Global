using System;
using System.Linq;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Models;

namespace Airline.DAL.Initializator
{
    public class Db_Airline_Initializer
    {
        public static void Initialize(AirlineContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Team_Persons.Any())
            {
                context.Team_Persons.AddRange(
                    new Team_Person { Name_Team = "Team_1" },
                    new Team_Person { Name_Team = "Team_2" },
                    new Team_Person { Name_Team = "Team_3" },
                    new Team_Person { Name_Team = "Team_4" });

                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                new Country { Name_Country = "Ukraine" },
                 new Country { Name_Country = "USA" },
                 new Country { Name_Country = "CHINA" });

                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City { Name_City = "Kharkov", AirportCode = "KHA", CountryId = 1 },
                    new City { Name_City = "Kherson", AirportCode = "KHE", CountryId = 1 },
                    new City { Name_City = "Odessa", AirportCode = "OD", CountryId = 1 },
                    new City { Name_City = "lviv", AirportCode = "LV", CountryId = 1 },
                    new City { Name_City = "Europe1", AirportCode = "EU1", CountryId = 2 },
                    new City { Name_City = "Europe2", AirportCode = "EU2", CountryId = 2 },
                    new City { Name_City = "Europe3", AirportCode = "EU3", CountryId = 2 },
                    new City { Name_City = "China1", AirportCode = "CH1", CountryId = 3 },
                    new City { Name_City = "China2", AirportCode = "Ch2", CountryId = 3 });

                context.SaveChanges();
            }

            if (!context.Navigators.Any())
            {
                context.Navigators.AddRange(
                    new Navigator { Name = "Navigator1", Experience = 9, Age = 44, Salary = 3400, Surname = "Petrov", Team_PersonId = 1 },
                new Navigator { Name = "Navigator2", Experience = 9, Age = 33, Salary = 2500, Surname = "Legurov", Team_PersonId = 2 },
                new Navigator { Name = "Navigator3", Experience = 3, Age = 33, Salary = 4900, Surname = "Chernen", Team_PersonId = 3 },
                new Navigator { Name = "Navigator4", Experience = 17, Age = 29, Salary = 3450, Surname = "Babenko", Team_PersonId = 4 });

                context.SaveChanges();
            }

            if (!context.Pilots.Any())
            {
                context.Pilots.AddRange(
                    new Pilot { Name = "Pilot1", Experience = 8, Age = 44, Salary = 4320, Surname = "Surmane_1", Team_PersonId = 1 },
                new Pilot { Name = "Pilot2", Experience = 12, Age = 33, Salary = 2451, Surname = "Surmane_2", Team_PersonId = 2 },
                new Pilot { Name = "Pilot3", Experience = 3, Age = 33, Salary = 2024, Surname = "Surmane_3", Team_PersonId = 3 });

                context.SaveChanges();
            }

            if (!context.Radio_Operators.Any())
            {
                context.Radio_Operators.AddRange(
                new Radio_operator { Name = "Radio_Operators1", Experience = 3, Salary = 2510, Age = 44, Surname = "Radio_Operators1", Team_PersonId = 1 },
                new Radio_operator { Name = "Radio_Operators2", Experience = 4, Salary = 3670, Age = 33, Surname = "Radio_Operators2", Team_PersonId = 2 },
                new Radio_operator { Name = "Radio_Operators3", Experience = 4, Salary = 2830, Age = 33, Surname = "Radio_Operators3", Team_PersonId = 3 },
                new Radio_operator { Name = "Radio_Operators4", Experience = 6, Salary = 1830, Age = 23, Surname = "Radio_Operators4", Team_PersonId = 4 });

                context.SaveChanges();
            }

            if (!context.Stewardesses.Any())
            {
                context.Stewardesses.AddRange(
                new Stewardess { Name = "Stewardesses1", Experience = 1, Salary = 2000, Age = 44, Surname = "Yurchenko1", Team_PersonId = 1 },
                new Stewardess { Name = "Stewardesses2", Experience = 14, Salary = 1000, Age = 33, Surname = "Yurchenko2", Team_PersonId = 2 },
                new Stewardess { Name = "Stewardesses3", Experience = 3, Salary = 3000, Age = 33, Surname = "Yurchenko3", Team_PersonId = 3 },
                new Stewardess { Name = "Stewardesses4", Experience = 5, Salary = 3500, Age = 23, Surname = "Yurchenko4", Team_PersonId = 4 });

                context.SaveChanges();
            }


            if (!context.Fligths.Any())
            {
                context.Fligths.AddRange(
                    new Fligth { Name_Fligth = "Flight_1", Price = 220.23m, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(1), DepartureDate = DateTime.UtcNow.AddDays(1), FromCityId = 1, WhereCityId = 2 },
                new Fligth { Name_Fligth = "Fligth_2", Price = 200, IsConfirmed = false, ArrivalDate = DateTime.UtcNow.AddDays(2), DepartureDate = DateTime.UtcNow.AddDays(1), FromCityId = 3, WhereCityId = 4 },
                new Fligth { Name_Fligth = "Fligth_3", Price = 350, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(3), DepartureDate = DateTime.UtcNow.AddDays(2), FromCityId = 5, WhereCityId = 6 },
                new Fligth { Name_Fligth = "Fligth_4", Price = 300, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(7), DepartureDate = DateTime.UtcNow.AddDays(7), FromCityId = 8, WhereCityId = 9 },
                new Fligth { Name_Fligth = "Fligth_5", Price = 245, IsConfirmed = false, ArrivalDate = DateTime.UtcNow.AddDays(4), DepartureDate = DateTime.UtcNow.AddDays(4), FromCityId = 2, WhereCityId = 8 },
                new Fligth { Name_Fligth = "Fligth_6", Price = 400, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(2), DepartureDate = DateTime.UtcNow.AddDays(2), FromCityId = 1, WhereCityId = 6 });

                context.SaveChanges();
            }

            if (!context.FligthTeams.Any())
            {
                context.FligthTeams.AddRange(
                    new FligthTeam { Team_PersonId = 1, FligthId = 1 },
                    new FligthTeam { Team_PersonId = 1, FligthId = 2 },
                    new FligthTeam { Team_PersonId = 1, FligthId = 4 },
                    new FligthTeam { Team_PersonId = 2, FligthId = 2 },
                    new FligthTeam { Team_PersonId = 2, FligthId = 4 },
                    new FligthTeam { Team_PersonId = 3, FligthId = 1 },
                    new FligthTeam { Team_PersonId = 4, FligthId = 3 });

                context.SaveChanges();
            }




            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { Name = "Denis", Group = "P122D" },
                    new Student { Name = "Vlad", Group = "R132E" },
                    new Student { Name = "Dima", Group = "P122D" },
                    new Student { Name = "Bob", Group = "P155d" });
                context.SaveChanges();
            };

            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                    new Teacher { Name = "Teacher1" },
                    new Teacher { Name = "Teacher2" },
                    new Teacher { Name = "Teacher3" },
                    new Teacher { Name = "Teacher4" });
                context.SaveChanges();
            }

            if (!context.Disciplines.Any())
            {
                context.Disciplines.AddRange(
                    new Discipline { Title = "Discipline1", Annotation = "Annotation1", TeacherId = 1 },
                    new Discipline { Title = "Discipline2", Annotation = "Annotation2", TeacherId = 1 },
                    new Discipline { Title = "Discipline3", Annotation = "Annotation3", TeacherId = 2 },
                    new Discipline { Title = "Discipline4", Annotation = "Annotation4", TeacherId = 3 });
                context.SaveChanges();
            }

            if (!context.StudDiscs.Any())
            {
                context.StudDiscs.AddRange(
                    new StudDisc() { DisciplineId = 1, StudentId = 1 },
                    new StudDisc { DisciplineId = 2, StudentId = 1 },
                    new StudDisc { DisciplineId = 4, StudentId = 1 },
                    new StudDisc { DisciplineId = 1, StudentId = 2 },
                    new StudDisc { DisciplineId = 4, StudentId = 2 },
                    new StudDisc { DisciplineId = 4, StudentId = 3 },
                    new StudDisc { DisciplineId = 1, StudentId = 4 });
                context.SaveChanges();

            }

        }
    }
}
