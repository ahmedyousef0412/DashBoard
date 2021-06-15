using AutoMapper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using DemoCore.DAL.Entity;
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
        private readonly IMapper mapper;

        public EmployeeRep(DataContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }




        public IEnumerable<EmployeeVM> Get()
        {
            var data = GetAllData();
            return data;
        }

        public EmployeeVM GetById(int id)
        {
            return GetById(id);
            
        }

        public IEnumerable<EmployeeVM> SearchByName(string name)
        {
            return SearchByName(name);
        }


        public void Create(EmployeeVM obj)
        {
            var data = mapper.Map<Employee>(obj);
            context.Employees.Add(data);
            context.SaveChanges();
        }


        public void Edit(EmployeeVM obj)
        {
            var data = mapper.Map<Employee>(obj);
            context.Entry(data).State = 
                Microsoft.EntityFrameworkCore.EntityState .Modified;

            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = context.Employees.Find(id);

            context.Employees.Remove(data);
            context.SaveChanges();
        }

        




        //////Refactor Method

        private IEnumerable<EmployeeVM> SearchByNameOnEmployee(string name)
        {

            //  here i don't need [FirstOrDefault] because I need Return [List]

            return context.Employees
                .Where(d => d.EmployeeName == name)
                .Select(d => new EmployeeVM
                {
                    Id = d.Id,
                    EmployeeName = d.EmployeeName,
                     Salary= d.Salary,
                    Address = d.Address,
                    Notes = d.Notes,
                    Email = d.Email,
                    IsActive = d.IsActive,
                    HireDate = d.HireDate,
                    DepartmentId = d.Department.DepartmentName
                     
                });
        }
        private EmployeeVM GetEmployeeById(int id)
        {
            var data = context.Employees
                .Where(d => d.Id == id)
                .Select(d => new EmployeeVM
                {

                    Id = d.Id,
                    EmployeeName = d.EmployeeName,
                    Salary = d.Salary,
                    Address = d.Address,
                    Notes = d.Notes,
                    Email = d.Email,
                    IsActive = d.IsActive,
                    HireDate = d.HireDate,
                    DepartmentId = d.Department.DepartmentName


                    
                }).FirstOrDefault();
            return data;
        }

        private IQueryable<EmployeeVM> GetAllData()
        {
            return context.Employees
                .Select(a => new EmployeeVM
                {

                    Id = a.Id,
                    EmployeeName = a.EmployeeName,
                    Salary = a.Salary,
                    Address = a.Address,
                    Notes = a.Notes,
                    Email = a.Email,
                    IsActive = a.IsActive,
                    HireDate = a.HireDate,
                    DepartmentId = a.Department.DepartmentName

                });
        }



    }
}
