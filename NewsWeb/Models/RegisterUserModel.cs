using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class RegisterUserModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Repeat e-mail")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email")]
        public string RepeatedEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat  assword")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatedPassword { get; set; }

        
    }
}
