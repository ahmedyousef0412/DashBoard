﻿using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DemoCore.DAL.Entity;

namespace DemoCore.BLL.Repository
{
    public   class DepartmentRep : IDepartmentRep
    {
        private readonly DataContext _context = new();

        public IEnumerable<DepartmentVM> Get()
       {
           var data = GetAllData();
           return data;
       }


        public DepartmentVM GetById(int id)
        {
            var context = _context.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentVM
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    Departmentcode = d.Departmentcode
                }).FirstOrDefault();
            return context;
        }

        public IEnumerable<DepartmentVM> SearchByName(string Name)
        {

            //  here i don't need [FirstOrDefault] because I need Return [List]

            var context = _context.Departments
                .Where(d => d.DepartmentName == Name)
                .Select(d => new DepartmentVM
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    Departmentcode = d.Departmentcode
                });

            return context;

        }

        public void Create(DepartmentVM obj)
        {



            Department department = new();

            // The DepartmentName That I recive it from user but it in DepartmentName object that i  create it.
            department.DepartmentName = obj.DepartmentName;

            // The DepartmentCode That I recive it from user but it in DepartmentCode object that i  create it.
            department.Departmentcode = obj.Departmentcode;

            _context.Departments.Add(department);
            _context.SaveChanges();


        }

        public void Edit(DepartmentVM obj)
        {
            //Catch By Id
            var oldData = _context.Departments.Find(obj.Id);

            // that i mean i catch the DepartmentName in database and replace it by obj.DepartmentName
            oldData.DepartmentName = obj.DepartmentName;

            // that i mean i catch the Departmentcode in database and replace it by obj.Departmentcode

            oldData.Departmentcode = obj.Departmentcode;

            
            _context.SaveChanges();

        }

        public void Delete(int id)
        {

        }

        /////////// Refactor Methods////

        private IQueryable<DepartmentVM> GetAllData()
        {
            return _context.Departments
                .Select(a => new DepartmentVM
                {
                    Id = a.Id,
                    DepartmentName = a.DepartmentName,
                    Departmentcode = a.Departmentcode
                });
        }



    }
}
