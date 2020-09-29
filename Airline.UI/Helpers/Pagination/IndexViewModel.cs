using System.Collections.Generic;
using Airline.DAL.Models;

namespace Airline_Yurchenko.Helpers.Pagination
{
    public class IndexViewModel
    {
        public IEnumerable<Pilot> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
