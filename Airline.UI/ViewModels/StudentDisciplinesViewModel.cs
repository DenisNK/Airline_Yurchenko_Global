using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.Models;

namespace Global_Logic_ASP.Core.ViewModels
{
    public class StudentDisciplinesViewModel
    {
        public Student Student{ get; set; }
        public IEnumerable<Discipline> IsChoose{ get; set; }
        public IEnumerable<Discipline> NoChoose{ get; set; }
    }
}
