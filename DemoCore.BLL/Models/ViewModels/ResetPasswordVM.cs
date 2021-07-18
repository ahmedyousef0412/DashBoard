using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
   public class ResetPasswordVM
    {


        [Required]
        [EmailAddress (ErrorMessage ="Email Adderss No Valid")]

        public string Email { get; set; }





        [Required]
        [DataType(DataType.Password , ErrorMessage ="Password Not Valid")]
        [MinLength(3 ,ErrorMessage ="Min Length 3")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password Not Valid")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        [Compare("Password" , ErrorMessage = "ConfirmPassword Not Matching")]
        [Display (Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        public string Token { get; set; }
    }
}
