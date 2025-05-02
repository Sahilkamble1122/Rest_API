using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace REST.model
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public int DepartmentId { get; set; }

        [ValidateNever]
        public department department { get; set; }
    }
}
