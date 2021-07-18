using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
 public   class EditRoleVM
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name Requird")]
        public string Name { get; set; }
    }
}
