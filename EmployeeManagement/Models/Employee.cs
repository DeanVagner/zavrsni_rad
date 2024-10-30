using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public required string FirstName { get; set; }  
        [Required]
        public required string LastName { get; set; }  
        [Required]
        public required string Email { get; set; }  
        [Required]
        public required string Position { get; set; }
        [Required]
        public required decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }  
        public DateTime HireDate { get; set; } 
    }
}