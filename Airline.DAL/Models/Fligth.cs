using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airline.DAL.Models
{
    public class Fligth : BaseId
    {
        [Required(ErrorMessage = "Please, input flight name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name_Fligth { get; set; }

        public virtual Country FromCountry { get; set; }

        public int? FromCityId { get; set; }

        public virtual City FromCity { get; set; }

        public virtual Country WhereCountry { get; set; }

        public int? WhereCityId { get; set; }

        public virtual City WhereCity { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public bool IsConfirmed { get; set; }

        [Required(ErrorMessage = "Please, input the price")]
        [Range(18, 7500)]
        public decimal Price { get; set; }

        public virtual ICollection<FligthTeam> FligthTeams { get; set; }
    }
}
