using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.DTO
{
    public class DeptDto
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        public string DepartmentName { get; set; }


        [Required(ErrorMessage = "Enter Department Code")]
        public string Departmentcode { get; set; }
    }
}
