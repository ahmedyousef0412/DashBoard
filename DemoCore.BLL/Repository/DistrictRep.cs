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
    public class DistrictRep : IDistricRep
    {
        private readonly DataContext context;

        public DistrictRep(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<District> Get()
        {
            return context.District.Select(d => d);

        }

        public District GetById(int id)
        {
            return context.District.Where(d => d.Id == id).FirstOrDefault();
        }
    }
}
