using AutoMapper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using DemoCore.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCore.BLL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DataContext context;
       

        public EmployeeRep(DataContext context )
        {
            this.context = context;
            
        }




        public IEnumerable<Employee> Get()
        {
            var data = context.Employees
                .Include(c=> c.Department)
                .Include(c =>c.District)
                .ToList();
            return data;
        }

        public Employee GetById(int id)
        {
            var data = context.Employees.Where(e => e.Id == id).FirstOrDefault();
            return data;
            
        }

        public IEnumerable<Employee> SearchByName(string name)
        {

            var data = context.Employees.Where(e => e.EmployeeName == name)
             .Select(e =>e);
            return data;
        }


        public void Create(Employee obj)
        {
           
            context.Employees.Add(obj);
            context.SaveChanges();
        }


        public void Edit(Employee obj)
        {
           
            context.Entry(obj).State =
                EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(Employee obj)
        {
           

            context.Employees.Remove(obj);
            context.SaveChanges();
        }

        




        //////Refactor Method

        //private IEnumerable<EmployeeVM> SearchByNameOnEmployee(string name)
        //{

        //    //  here i don't need [FirstOrDefault] because I need Return [List]

        //    return context.Employees
        //        .Where(d => d.EmployeeName == name)
        //        .Select(d => new EmployeeVM
        //        {
        //            Id = d.Id,
        //            EmployeeName = d.EmployeeName,
        //             Salary= d.Salary,
        //            Address = d.Address,
        //            Notes = d.Notes,
        //            Email = d.Email,
        //            IsActive = d.IsActive,
        //            HireDate = d.HireDate,
        //            DepartmentId = d.Department.DepartmentName
                     
        //        });
        //}
        //private EmployeeVM GetEmployeeById(int id)
        //{
        //    var data = context.Employees
        //        .Where(d => d.Id == id)
        //        .Select(d => new EmployeeVM
        //        {

        //            Id = d.Id,
        //            EmployeeName = d.EmployeeName,
        //            Salary = d.Salary,
        //            Address = d.Address,
        //            Notes = d.Notes,
        //            Email = d.Email,
        //            IsActive = d.IsActive,
        //            HireDate = d.HireDate,
        //            DepartmentId = d.Department.DepartmentName


                    
        //        }).FirstOrDefault();
        //    return data;
        //}

        //private IQueryable<EmployeeVM> GetAllData()
        //{
        //    return context.Employees
        //        .Select(a => new EmployeeVM
        //        {

        //            Id = a.Id,
        //            EmployeeName = a.EmployeeName,
        //            Salary = a.Salary,
        //            Address = a.Address,
        //            Notes = a.Notes,
        //            Email = a.Email,
        //            IsActive = a.IsActive,
        //            HireDate = a.HireDate,
        //            DepartmentId = a.Department.DepartmentName

        //        });
        //}



    }
}
