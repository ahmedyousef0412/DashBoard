using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DemoCore.DAL.Entity;
using AutoMapper;
using DemoCore.BLL.DTO;
using Microsoft.EntityFrameworkCore;

namespace DemoCore.BLL.Repository
{
    public   class DepartmentRep : IDepartmentRep
    {
        private readonly DataContext context;
       

        public DepartmentRep(DataContext context  )
        {
            this.context = context;
            
        }

        public void Create(Department obj)
        {
            context.Departments.Add(obj);
            context.SaveChanges();
        }

       

        public void Delete(Department obj)
        {
            context.Departments.Remove(obj);
            context.SaveChanges();
        }

        public void Edit(Department obj)
        {
            context.Entry(obj).State
                 = EntityState.Modified;
            context.SaveChanges();
        }

       

        

        public Department GetById(int id)
        {
            var data = context.Departments.Where(d => d.Id == id)
             .FirstOrDefault();
            return data;
        }

        public IEnumerable<Department> SearchByName(string name)
        {
            var data = context.Departments.Where(d => d.DepartmentName == name)
                .Select(d => d);

            return data;
        }

        IEnumerable<Department> IDepartmentRep.Get()
        {
            var data = context.Departments.Select(d => d);
            return data;
        }





        #region Refactor Method

        /////////// Refactor Methods////


        //private IEnumerable<DeptDto> SearchByNameOnDepartment(string name)
        //{

        //    //  here i don't need [FirstOrDefault] because I need Return [List]

        //    return context.Departments
        //        .Where(d => d.DepartmentName == name)
        //        .Select(d => new DepartmentVM
        //        {
        //            Id = d.Id,
        //            DepartmentName = d.DepartmentName,
        //            Departmentcode = d.Departmentcode
        //        });
        //}
        //private DeptDto GetDepartmentById(int id)
        //{
        //    var data = context.Departments
        //        .Where(d => d.Id == id)
        //        .Select(d => new DepartmentVM
        //        {
        //            Id = d.Id, // d.Id Mean The Id in Entity Department
        //            DepartmentName = d.DepartmentName, //d.DepartmentName Mean The DepartmentName in Entity Department
        //            Departmentcode = d.Departmentcode // d.DepartmentCode Mean The  d.DepartmentCode in Entity Department

        //            //to Show them I Forms I will Create it
        //        }).FirstOrDefault();
        //    return data;
        //}

        //private IEnumerable<Department> GetAllData()
        //{
        //    var data = context.Departments.Select(x => x);
        //    return data;
        //}
        #endregion





    }
}
