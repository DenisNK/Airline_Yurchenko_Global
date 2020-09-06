using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.ValidationAttribut;

namespace Global_Logic_ASP.Core.ViewModels
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

        [Required(ErrorMessage = "Please, input your Group")]
        public string Group{ get; set; }

    }
}
