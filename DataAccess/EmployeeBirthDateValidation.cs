using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Core.Validation
{
    public class BirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var configuration = (IConfiguration)validationContext.GetService(typeof(IConfiguration));

            if (configuration == null)
            {
                return null;
            }

            var dateOfBirth = (DateTime)value;

            if (dateOfBirth >= DateTime.Now)
            {
                return new ValidationResult("Date of birth cannot be in the future.");
            }

            int.TryParse(configuration["MinYear"], out var minYear);

            if (dateOfBirth.Year <= minYear)
            {
                return new ValidationResult("Date of birth cannot be earlier then 1900.");
            }

            return ValidationResult.Success;
        }
    }
}
