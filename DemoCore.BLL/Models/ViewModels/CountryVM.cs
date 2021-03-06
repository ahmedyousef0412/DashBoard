using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Models.ViewModels
{
   public class CountryVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
