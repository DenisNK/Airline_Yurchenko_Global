using System.Collections.Generic;

namespace Airline.DAL.Models
{
    public class Country : BaseId
    {
        public string Name_Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}
