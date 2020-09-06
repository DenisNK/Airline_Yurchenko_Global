using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class Teacher : BaseId, IEntity
    {
        [Required(ErrorMessage = "Please, input teacher name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
        public List<Discipline> Discipline { set; get; }
    }
}