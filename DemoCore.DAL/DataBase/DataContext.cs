using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoCore.DAL.DataBase
{

    /*
       I Use IdentityDbContext Instead Of DbContext Because
        I Need To Use Classes In
       IdentityDbContext and  IdentityDbContext 
       Inherit From DbContext and Show EveryThing In DbContext.
     */
    public class DataContext :IdentityDbContext
    {

        // This is How Enhancement in Connection String
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){ }

        public DbSet<Department> Departments { get; set; }


        public DbSet<Employee> Employees { get; set; }


        public DbSet<Country> Country { get; set; }


        public DbSet<City> City { get; set; }


        public DbSet<District> District { get; set; }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = .; database = CoreDB; Integrated Security = true");
        //}
    }

}
