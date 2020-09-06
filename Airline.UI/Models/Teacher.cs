using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;

namespace Global_Logic_ASP.Core.Models
{
    public class Teacher:BaseId, IEntity
    {
        [Required(ErrorMessage = "Please, input teacher name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
        public List<Discipline> Discipline { set; get; }
    }
}
