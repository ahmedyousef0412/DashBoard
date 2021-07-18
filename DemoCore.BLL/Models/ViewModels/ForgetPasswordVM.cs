using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Requird")]
        [EmailAddress(ErrorMessage = "Email Not Valid")]
        public string Email { get; set; }

    }
}
