using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
   public class LoginVM
    {
        [Required(ErrorMessage ="UserName Required")]
        [Display(Name =" User Name")]
        public string Email { get; set; }


        [Required]
        [MinLength(3 , ErrorMessage ="Min Length 3")]
        [DataType(DataType.Password , ErrorMessage ="Password Requird")]
        public string Password { get; set; }


        
        public bool RememberMe { get; set; }
    }
}
