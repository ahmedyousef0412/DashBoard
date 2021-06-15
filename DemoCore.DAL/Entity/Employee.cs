using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
    [Table ("Employee")]
    public class Employee
    {

        [Key]
        public int Id { get; set; }


        [Display(Name ="Name")]
        [Required(ErrorMessage = "Enter Employee Name")]
        [StringLength(50)]
        
        public string EmployeeName { get; set; }


        public float Salary { get; set; }



        public string Address { get; set; }




        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }


        public string  Notes { get; set; }

        public string Email { get; set; }


        public int DepartmentId { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

    }
}
