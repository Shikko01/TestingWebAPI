using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Core.Validation
{
    public class LateDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var minYear = 1900;

            if (value == null)
            {
                return true;
            }

            var dateOfBirth = (DateTime)value;
            return dateOfBirth.Year >= minYear;
        }
    }
}
