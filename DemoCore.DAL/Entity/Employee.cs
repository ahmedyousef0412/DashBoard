using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
    [Table ("Employee")] // The Name I need To Create The Table Like It.
    public class Employee
    {

        [Key] //Mean This Is Primary Key
        public int Id { get; set; }


      
        [StringLength(50)]
        
        public string EmployeeName { get; set; }


        public float Salary { get; set; }

        public string Address { get; set; }


        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; }


        public string PhotoUrl { get; set; }

        public string CvUrl { get; set; }
        public string  Notes { get; set; }

        public string Email { get; set; }



       
        public int DepartmentId { get; set; }


        [ForeignKey("DepartmentId")]
        //Navigation Property [Mean I used It Forign Key]
        public virtual Department Department { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

    }
}
