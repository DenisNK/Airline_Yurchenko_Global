using System.ComponentModel.DataAnnotations;
using Airline.DAL.IRepository;

namespace Airline.DAL.Models
{
    public class UserProfile : BaseId, IEntity
    {
        //[Forbidden("xxx", "yyy")]
        [Required(ErrorMessage = "Please, input your name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Please, input your Gender")]
        public string Gender { set; get; }
    }
}
