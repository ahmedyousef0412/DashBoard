using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.DTO
{
    public class EmpDto
    {
        [Key] //Mean This Is Primary Key
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter Employee Name")]
        [StringLength(50)]

        public string EmployeeName { get; set; }


        public float Salary { get; set; }

        public string Address { get; set; }


        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }


        public string Notes { get; set; }

        public string Email { get; set; }

        //Navigation Property [Mean I used It Forign Key]
        public int DepartmentId { get; set; }


        
    }
}
