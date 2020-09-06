using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class Student : BaseId, IEntity
    {
       // [Forbidden("xxx", "yyy")]
        [Required(ErrorMessage = "Please, input your name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Please, input your Group")]
        public string Group { set; get; }
        public List<StudDisc> StudDiscs { set; get; }
    }
}
