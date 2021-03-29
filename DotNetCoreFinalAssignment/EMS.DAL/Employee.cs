using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.BE
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name Cannot Contain More Than 50 Char.")]
        public string Name { get; set; }

        [ForeignKey("Department")]
        public Guid departmentId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Manager")]
        public bool IsManager { get; set; } = false;

        //[ForeignKey("Employee")]
        public Guid ManagerId { get; set; }

        [Required]
        [Phone]
        public decimal PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //Navigation Proeperty
        public Department department { get; set; }
    }
}
