using DemoCore.BLL.Interfaces;
using DemoCore.DAL.DataBase;
using DemoCore.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly DataContext context;

        public CityRep(DataContext  context)
        {
            this.context = context;
        }
        public IEnumerable<City> Get()
        {

            return context.City.Select(c => c);
        }

        public City GetById(int id)
        {
            return context.City.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
