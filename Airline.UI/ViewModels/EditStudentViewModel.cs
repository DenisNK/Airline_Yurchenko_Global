using System.ComponentModel.DataAnnotations;
using Airline_Yurchenko.ValidationAttribute;

namespace Airline_Yurchenko.ViewModels
{
    public class EditStudentViewModel
    {
        public string Id { get; set; }

        [Forbidden("xxx", "yyy")]
        [Required(ErrorMessage = "Please, input your name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Please, input your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, input your Gender")]
        public string Gender{ get; set; }

    }
}
