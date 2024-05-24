namespace Core.DTO
{
    public class EmployeeCreateUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
    }
}
