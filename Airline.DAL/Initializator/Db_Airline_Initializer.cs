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
