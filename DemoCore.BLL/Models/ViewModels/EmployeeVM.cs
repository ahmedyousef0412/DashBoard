using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public IFormFile Photo { get; set; }

        public IFormFile CV { get; set; }
        public string PhotoUrl { get; set; }

        public string CvUrl { get; set; }

        [Required(ErrorMessage = "Choose Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department  Department { get; set; }



        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }


    }
}
