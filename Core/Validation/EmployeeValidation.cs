using System.ComponentModel.DataAnnotations;

namespace Core.Validation
{
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            DateTime dateOfBirth = (DateTime)value;
            return dateOfBirth <= DateTime.Now;
        }
    }

    public class LateDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int minYear = 1900;

            if (value == null)
            {
                return true;
            }

            DateTime dateOfBirth = (DateTime)value;
            return dateOfBirth.Year >= minYear;
        }
    }
}
