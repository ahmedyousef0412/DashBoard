using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
   public class RegistrationVM
    {

        [Required(ErrorMessage ="UserName Requird")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="You Must Enter Valid Mail.")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage ="Min Length 3")]
        [Required(ErrorMessage = "Password Requird")]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        [Required]
        [Compare("Password" , ErrorMessage ="Password Not Match")]
        [Display(Name = "Confirm Password ")] // If Using A Label
        public string ConfirmPassword { get; set; }
    }
}
