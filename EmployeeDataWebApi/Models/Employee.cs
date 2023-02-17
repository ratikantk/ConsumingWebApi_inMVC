using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDataWebApi.Models
{
    public class Employee
    {

        [Key]       
        public int EmpId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
