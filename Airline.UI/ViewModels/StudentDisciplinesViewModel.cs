using System.Collections.Generic;
using Airline.DAL.Models;

namespace Airline_Yurchenko.ViewModels
{
    public class StudentDisciplinesViewModel
    {
        public Student Student{ get; set; }
        public IEnumerable<Discipline> IsChoose{ get; set; }
        public IEnumerable<Discipline> NoChoose{ get; set; }
    }
}
