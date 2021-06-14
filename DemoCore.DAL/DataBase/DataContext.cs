using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoCore.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoCore.DAL.DataBase
{
   public class DataContext :DbContext
    {


        public DataContext(DbContextOptions<DataContext> opts): base(opts)
        {
           
        }

        public DbSet<Department> Departments { get; set; }


        //public DbSet<Employee> Employees { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = .; database = CoreDB; Integrated Security = true");
        //}
    }

}
