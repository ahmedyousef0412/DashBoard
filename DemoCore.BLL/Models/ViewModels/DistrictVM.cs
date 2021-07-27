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
   public class DistrictVM
    {
        public int Id { get; set; }


        [Required]
        public string DistrictName { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")] 
        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
