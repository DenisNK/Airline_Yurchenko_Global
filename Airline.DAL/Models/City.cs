using System.ComponentModel.DataAnnotations;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class City : BaseId, IEntity
    {
        [Required(ErrorMessage = "Please, input city name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name_City { get; set; }

        [Required(ErrorMessage = "Please, input AirportCode")]
        public string AirportCode { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
