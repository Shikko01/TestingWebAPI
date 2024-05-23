using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Employee Name must be between 2 and 50 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Employee Lasty Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Employee Last Name must be between 2 and 50 characters")]
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}
