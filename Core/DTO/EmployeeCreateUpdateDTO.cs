using System.ComponentModel.DataAnnotations;
using Core.Validation; 

namespace Core.DTO
{
    public class EmployeeCreateUpdateDTO
    {
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Employee Name must be between 2 and 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Employee Last Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Employee Last Name must be between 2 and 50 characters")]
        public string LastName { get; set; }

        [BirthDate]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
    }
}
