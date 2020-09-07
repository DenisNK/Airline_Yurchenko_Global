using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Airline.DAL.Models;

namespace Airline_Yurchenko.ViewModels
{
    public class FligthListViewModels
    {
        public Fligth Fligth{ get; set; } 
        public IEnumerable<Team_Person> IsChoose { get; set; }
        public IEnumerable<Team_Person> NoChoose { get; set; }
    }
}
