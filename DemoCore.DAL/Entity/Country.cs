using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.DAL.Entity
{
   public class Country
    {

        public Country()
        {
            City = new HashSet<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> City { get; set; }

    }
}
