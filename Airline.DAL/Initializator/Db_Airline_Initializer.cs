﻿using System;
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
                    new Country { Name_Country = "CHINA" },
                    new Country { Name_Country = "USA" },
                    new Country { Name_Country = "Ukraine" });

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
                    new Pilot { Name = "Pilot1", Experience = 8, Age = 44, Salary = 4320, Surname = "Surmane_1", ProfilePicture = "46f4a1d1-c375-4bdf-9b46-469b9345bf28_Pilot_logo (1).png", Team_PersonId = 1 },
                    new Pilot { Name = "Pilot2", Experience = 12, Age = 33, Salary = 3451, Surname = "Surmane_2", ProfilePicture = "9471465b-18f0-405e-8b17-913f89e78fe8_Pilot_logo (2).png", Team_PersonId = 2 },
                    new Pilot { Name = "Pilot3", Experience = 3, Age = 43, Salary = 3084, Surname = "Surmane_3", ProfilePicture = "d86c0f0a-3ccf-4516-a671-d1930d47122f_Pilot_logo (4).png", Team_PersonId = 3 },
                    new Pilot { Name = "Pilot4", Experience = 23, Age = 28, Salary = 2524, Surname = "Surmane_4", ProfilePicture = "e5de017b-7479-4e7c-bd7e-9a5586616bd9_Pilot_logo (3).png", Team_PersonId = 4 });

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
                    new Stewardess { Name = "Stewardesses1", Experience = 1, Salary = 2000, Age = 44, Surname = "Yurchenko1", ProfilePicture = "2a848519-1df4-4b00-9efa-217ee7ce0afd_Stewardess_Logo (4).png", Team_PersonId = 1 },
                    new Stewardess { Name = "Stewardesses2", Experience = 14, Salary = 1000, Age = 33, Surname = "Yurchenko2", ProfilePicture = "a083bb67-c22b-4e59-8f88-04daa1c7cbc6_Stewardess_Logo (3).png", Team_PersonId = 2 },
                    new Stewardess { Name = "Stewardesses3", Experience = 3, Salary = 3000, Age = 33, Surname = "Yurchenko3", ProfilePicture = "b494321c-b363-4b4f-a3ba-2612df8723f8_Stewardess_Logo (2).png", Team_PersonId = 3 },
                    new Stewardess { Name = "Stewardesses4", Experience = 5, Salary = 3500, Age = 23, Surname = "Yurchenko4", ProfilePicture = "aeb5b431-28ed-4f6d-be2d-41ef1239aa70_Stewardess_Logo (1).png", Team_PersonId = 4 });

                context.SaveChanges();
            }

            if (!context.Fligths.Any())
            {
                context.Fligths.AddRange(
                    new Fligth { Name_Fligth = "Flight_1", Price = 220.23m, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(1), DepartureDate = DateTime.UtcNow.AddDays(1), FromCityId = 1, WhereCityId = 2},
                    new Fligth { Name_Fligth = "Fligth_2", Price = 200, IsConfirmed = false, ArrivalDate = DateTime.UtcNow.AddDays(2), DepartureDate = DateTime.UtcNow.AddDays(1), FromCityId = 3, WhereCityId = 4},
                    new Fligth { Name_Fligth = "Fligth_3", Price = 350, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(3), DepartureDate = DateTime.UtcNow.AddDays(2), FromCityId = 5, WhereCityId = 6},
                    new Fligth { Name_Fligth = "Fligth_4", Price = 300, IsConfirmed = true, ArrivalDate = DateTime.UtcNow.AddDays(7), DepartureDate = DateTime.UtcNow.AddDays(7), FromCityId = 8, WhereCityId = 9},
                    new Fligth { Name_Fligth = "Fligth_5", Price = 245, IsConfirmed = false, ArrivalDate = DateTime.UtcNow.AddDays(4), DepartureDate = DateTime.UtcNow.AddDays(4), FromCityId = 2, WhereCityId = 8},
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

            if (!context.Requests.Any())
            {
                context.Requests.AddRange(
                    new Request() { RequestRef = 1, Message = "Problem with open Window", SignIn = "Dispatcher@gmail.com" },
                    new Request() { RequestRef = 2, Message = "Power connection problem", SignIn = "Dispatcher@gmail.com" },
                    new Request() { RequestRef = 3, Message = "Problem with putting luggage", SignIn = "Dispatcher2@gmail.com" },
                    new Request() { RequestRef = 4, Message = "", SignIn = "Dispatcher2@gmail.com" },
                    new Request() { RequestRef = 5, Message = "Team placement problem", SignIn = "Dispatcher@gmail.com" },
                    new Request() { RequestRef = 6, Message = "", SignIn = "Admin@gmail.com" });

                context.SaveChanges();
            }

        }
    }
}
