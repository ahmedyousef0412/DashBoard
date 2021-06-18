using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
    public class EmployeeVM
    {

        [Key]
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required]
        [StringLength(50)]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        public string EmployeeName { get; set; }



        [Required(ErrorMessage = "Enter Employee Salary")]
        [Range(8000, 10000, ErrorMessage = "Salary Must be From 8000K : 10000K ")]
        public float Salary { get; set; }



        [Required(ErrorMessage = "Enter Employee Address")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter Like 12-StreetName-CityName-CountryName")]
        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }


        public string Notes { get; set; }

        public string Email { get; set; }

        public string DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

    }
}
