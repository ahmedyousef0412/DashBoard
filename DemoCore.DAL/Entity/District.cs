using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
    public class District
    {
        /*
          Use HashSet<Table> For Return Data Without Duplicated

          Use it when My Entity have ICollection
         
        */
        public District()
        {
            Employee = new HashSet<Employee>();
        }
        [Key]
        public int Id { get; set; }

        public string DistrictName { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        /*
           I use [virtual] Taht Mean I Work Using Eager Load
           When City Will Call Country


         "[The Default Is Lazy Load] => Don't Return The Related Entity
         */
        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
