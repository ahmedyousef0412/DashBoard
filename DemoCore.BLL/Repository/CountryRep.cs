using AutoMapper;
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


      
    public class CountryRep : ICountryRep
    {
        private readonly DataContext context;

        public CountryRep(DataContext context  )
        {
            this.context = context;
        }
        public IEnumerable<Country> Get()
        {
            return context.Country.Select(c => c);
        }

        public Country GetById(int id)
        {
            return context.Country.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
