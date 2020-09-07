using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Airline_Yurchenko.ValidationAttribute
{
    public class ForbiddenAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
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
