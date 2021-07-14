using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
    public class MailVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Field Can't be Empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field Can't be Empty")]
        public string Message { get; set; }


        [Required(ErrorMessage = "Field Can't be Empty ")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is Not Vaild")]
        public string UserName { get; set; }

    }
}