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

            var dateOfBirth = (DateTime)value;
            return dateOfBirth <= DateTime.Now;
        }
    }
}
