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
       

        public DepartmentRep(DataContext context)
        {
            this.context = context;
            
        }

        public Department GetById(int id)
        {
            var data = context.Departments
                 .Where(d => d.Id == id)
                 .FirstOrDefault();
            return data;
        }

        public IEnumerable<Department> SearchByName(string name)
        {
            var data = context.Departments
                .Where(d => d.DepartmentName == name)
                .Select(d => d);

            return data;
        }

        IEnumerable<Department> IDepartmentRep.Get()
        {
            var data = context.Departments.Select(d => d);
            return data;
        }


        public void Create(Department obj)
        {
            context.Departments.Add(obj);
            context.SaveChanges();
        }

        public void Edit(Department obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Department obj)
        {
            context.Departments.Remove(obj);
            context.SaveChanges();
        }

       



        #region Before Using AutoMapper
        /// <summary>
        ///  Here I Use [Select] Because make Function Return VM 
        ///  and VM Must Speak Entity to Reurn Data
        ///  Id = x.Id [Id ==> This VM] x.Id ==> This Entity]
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // public DepartmentVM GetById(int id)
        // {



        //     var data = context.Departments
        //          .Where(d => d.Id == id).Select(x => new DepartmentVM
        //          {
        //              Id = x.Id,
        //              DepartmentName = x.DepartmentName,
        //              Departmentcode = x.Departmentcode
        //          })
        //          .FirstOrDefault();
        //     return data;
        // }

        // public IEnumerable< DepartmentVM> SearchByName(string Name)
        // {



        //     var data = context.Departments
        //          .Where(d => d.DepartmentName == Name)
        //          .Select(x => new DepartmentVM
        //          {
        //              Id = x.Id,
        //              DepartmentName = x.DepartmentName,
        //              Departmentcode = x.Departmentcode
        //          });

        //     return data;
        // }



        // public void Create(DepartmentVM Obj)
        // {

        //     var dept = new Department();
        //     dept.DepartmentName = Obj.DepartmentName;
        //     dept.Departmentcode = Obj.Departmentcode;


        //     var data = context.Departments.Add(dept);
        //     context.SaveChanges();

        // }





        // public void Edit(DepartmentVM Obj)
        // {

        //     var oldData = context.Departments.Find(Obj.Id);
        ////The Data in Entity[in DB]  //[The New Data]    
        //     oldData.DepartmentName = Obj.DepartmentName;
        //     oldData.Departmentcode = Obj.Departmentcode;

        //     context.SaveChanges();
        // }


        // public void Delete(int Id)
        // {
        //     var OldData = context.Departments.Find(Id);

        //     context.Departments.Remove(OldData);

        //     context.SaveChanges();
        // }


        #endregion




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
