using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class StudDisc : IEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int Id { get; set; }
    }
}