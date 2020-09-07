using System.ComponentModel.DataAnnotations;

namespace Airline_Yurchenko.ViewModels
{
    public class EditTeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, input teacher name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
    }
}
