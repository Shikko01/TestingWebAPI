using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class EmployeeCreateDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
