using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDataMVC.Models
{
    public class mvcEmployee
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
