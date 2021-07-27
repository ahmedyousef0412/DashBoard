using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.BLL.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using DemoCore.BLL.Interfaces;
using System.Diagnostics;
using DemoCore.BLL.DTO;
using AutoMapper;
using DemoCore.DAL.Entity;

namespace DemoCore.Controllers
{
    public class DepartmentController1 : Controller
    {
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;


        //Loosly Coupled

        public DepartmentController1(IDepartmentRep departmentRep ,IMapper mapper)
        {
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        }

        #region Tightly Coupled

        //private readonly DepartmentRep departmentRep;

        //public DepartmentController1(DepartmentRep departmentRep)
        //{
        //    this.departmentRep = departmentRep;
        //}



        // That We How Achive Dependency Injection
        #endregion


       
     

        // The [SearchValue] Come From Attribute [name] in Index View

        public IActionResult Index(string SearchValue = null)
        {
             

           
            if (string.IsNullOrEmpty(SearchValue))
            {

                var data = departmentRep.Get();
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
             
                return View(result);
            }
            else
            {

                var data = departmentRep.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
                return View(result);
            }

        }


        public IActionResult Details(int id)
        {

           

            var data = departmentRep.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);
            return View(result);
            
            
            
        }


        //This Action Just for Form View 
        public IActionResult Create()
        {
            return View();
        }


        //This Action responsibility for Receive Data Return From The [Form] 
        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {

                if (ModelState.IsValid) //Using Validation
                {

                    //Dpartment in Map Is The Entity Which  I Save Data In 
                    // (model) Is The Source Which Department take Data From It.

                    var data = mapper.Map<Department>(model);
                    departmentRep.Create(data);

                    return RedirectToAction("Index");
                }

                return View();
             }
            catch (Exception )
            {
                //EventLog log = new();
                //log.Source = "Admin DashBoard";
                //log.WriteEntry(e.Message, EventLogEntryType.Error);
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            var olddata = departmentRep.GetById(id);
            var result = mapper.Map<DepartmentVM>(olddata);

            return View(result);
            
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                     departmentRep.Edit(data);
                    return RedirectToAction("Index");
                }
              
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var olddata = departmentRep.GetById(id);
            var result = mapper.Map<DepartmentVM>(olddata);

            return View(result);
        }

       [HttpPost]
       //I Can Recieve (int Id) 
        public IActionResult Delete(DepartmentVM model)
        {

            try 
            {

                var data = departmentRep.GetById(model.Id);

                departmentRep.Delete(data);
                return RedirectToAction("Index");
            }
            catch (Exception)
            { 
                return View();
            }

            
        }

        
    }
}
