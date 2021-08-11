using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please enter your email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        [Display(Name ="Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter a password")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Please Re-enter the password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Both Password Field Didn't match")]
        public string ConfirmPassword { get; set; }
    }
}
