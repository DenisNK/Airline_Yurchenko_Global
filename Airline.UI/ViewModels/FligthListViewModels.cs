using System.Collections.Generic;
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
