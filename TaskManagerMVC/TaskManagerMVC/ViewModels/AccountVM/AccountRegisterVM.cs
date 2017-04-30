using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.ViewModels.AccountVM
{
    public class AccountRegisterVM
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Please enter a username!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Username is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username shoudl contain between 3 and 50 characters")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter an email address!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email should contain between 5 and 70 characters")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Your name should contain between 3 and 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        [RegularExpression(@"^([A-z]+)$", ErrorMessage = "Name should consist only letters!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Your name should contain between 3 and 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}