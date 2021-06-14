using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DemoCore.DAL.Entity;
using AutoMapper;

namespace DemoCore.BLL.Repository
{
    public   class DepartmentRep : IDepartmentRep
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public DepartmentRep(DataContext context , IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }

     
        
        public IEnumerable<DepartmentVM> Get()
       {
           var data = GetAllData();
           return data;
       }


        public DepartmentVM GetById(int id)
        {
            return GetDepartmentById(id);
        }


        public IEnumerable<DepartmentVM> SearchByName(string name)
        {
            return SearchByNameOnDepartment(name);

        }


        public void Create(DepartmentVM obj)
        {

            var department = mapper.Map<Department>(obj);

            context.Departments.Add(department);
            context.SaveChanges();


        }

        public void Edit(DepartmentVM obj)
        {
            //Catch By Id
            //var oldData = context.Departments.Find(obj.Id);

            //// that i mean i catch the DepartmentName in database and replace it by obj.DepartmentName
            //oldData.DepartmentName = obj.DepartmentName;

            //// that i mean i catch the DepartmentCode in database and replace it by obj.DepartmentCode

            //oldData.Departmentcode = obj.Departmentcode;


            var department = mapper.Map<Department>(obj);
            context.Entry(department).State = 
                Microsoft.EntityFrameworkCore.EntityState.Modified;

            
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var oldData = context.Departments.Find(id);

            context.Departments.Remove(oldData);
            context.SaveChanges();
        }





        /////////// Refactor Methods////


        private IEnumerable<DepartmentVM> SearchByNameOnDepartment(string name)
        {

            //  here i don't need [FirstOrDefault] because I need Return [List]

            return context.Departments
                .Where(d => d.DepartmentName == name)
                .Select(d => new DepartmentVM
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    Departmentcode = d.Departmentcode
                });
        }
        private DepartmentVM GetDepartmentById(int id)
        {
            var data = context.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentVM
                {
                    Id = d.Id, // d.Id Mean The Id in Entity Department
                    DepartmentName = d.DepartmentName, //d.DepartmentName Mean The DepartmentName in Entity Department
                    Departmentcode = d.Departmentcode // d.DepartmentCode Mean The  d.DepartmentCode in Entity Department

                    //to Show them I Forms I will Create it
                }).FirstOrDefault();
            return data;
        }

        private IQueryable<DepartmentVM> GetAllData()
        {
            return context.Departments
                .Select(a => new DepartmentVM
                {
                    Id = a.Id,
                    DepartmentName = a.DepartmentName,
                    Departmentcode = a.Departmentcode
                });
        }



    }
}
