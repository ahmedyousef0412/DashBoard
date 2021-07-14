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

        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password , ErrorMessage ="Password Requird")]
        public string Password { get; set; }


        
        public bool RememberMe { get; set; }
    }
}
