using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Logic_ASP.Core.ValidationAttribut
{
    public class ForbiddenAttribute : ValidationAttribute
    {
        string[] _forbiddens;

        public ForbiddenAttribute(params string[] forbiddens)
        {
            _forbiddens = forbiddens;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_forbiddens.Any(w => (string)value == w))
            {
                var errMess = $"{validationContext.DisplayName} is a forbidden word.";
                return new ValidationResult(errMess);
            }
            return ValidationResult.Success;
        }
    }
}
