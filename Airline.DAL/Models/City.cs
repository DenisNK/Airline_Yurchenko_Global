using System.ComponentModel.DataAnnotations;

namespace Airline.DAL.Models
{
    public class City : BaseId
    {
        [Required(ErrorMessage = "Please, input city name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name_City { get; set; }

        [Required(ErrorMessage = "Please, input city name")]
        public string AirportCode { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
