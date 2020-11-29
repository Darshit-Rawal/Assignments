using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class Registration
    {   
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "BirthDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Age")]
        [ReadOnly(true)]
        [Range(12, 120, ErrorMessage = "Age Must Be Between 12 to 120 Years")]
        public int Age { get; private set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Email Not Matched")]
        [Display(Name = "Confirm Email Address")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string MobileNumber { get; set; }

        [Required]
        [Url]
        public string GitHubURL { get; set; }
    }
}