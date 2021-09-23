using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
   public class City
    {
        /*
          Use HashSet<Table> For Return Data Without Duplicated

          Use it when My Entity have ICollection
         
        */

        public City()
        {
            District = new HashSet<District>();
        }

        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]

        /*
           I use [virtual] Taht Mean I Work Using Lazy Load
           When City Will Call Country


         "[The Default Is Eager Load] => Don't Return The Related Entity
         */
        public virtual Country Country { get; set; }

        public virtual ICollection<District> District { get; set; }



    }
}
