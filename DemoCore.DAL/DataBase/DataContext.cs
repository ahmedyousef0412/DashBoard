﻿using System;
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
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = .; database = CoreDB; Integrated Security = true");
        }
    }

}
