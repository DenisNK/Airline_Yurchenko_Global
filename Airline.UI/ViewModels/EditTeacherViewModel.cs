using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Logic_ASP.Core.ViewModels
{
    public class EditTeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, input teacher name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should not be longer than 20 characters.")]
        public string Name { set; get; }
    }
}
