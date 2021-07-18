using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
  public  class CreateRoleVM
    {
        [Required(ErrorMessage ="Role Name Requird")]
        public string RoleName { get; set; }
    }
}
