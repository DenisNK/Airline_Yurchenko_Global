using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;

namespace Global_Logic_ASP.Core.Models
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
