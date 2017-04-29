using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerMVC.ViewModels.AccountVM
{
    public class AccountLoginVM
    {
        [Required(ErrorMessage = "Please enter a username!")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Username is not valid!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username shoudl contain between 3 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password!")]
        public string Password { get; set; }

        public string RedirectUrl { get; set; }
    }
}