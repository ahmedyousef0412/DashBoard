using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        public string Departmentcode { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }


        // to told here the relation between the Employee and Department is [one to many]
        //public ICollection<Employee> Employee { get; set; }
    }
}
