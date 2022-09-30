using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpUserModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Password anad confirm pssword not matching")]
        [Display(Name = "Password ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm Password ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

       
    }
}
