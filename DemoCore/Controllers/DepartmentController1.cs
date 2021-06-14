using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.BLL.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using DemoCore.BLL.Interfaces;

namespace DemoCore.Controllers
{
    public class DepartmentController1 : Controller
    {
        private readonly IDepartmentRep departmentRep;




        //Loosly Coupled

        public DepartmentController1(IDepartmentRep departmentRep)
        {
            this.departmentRep = departmentRep;
        }
        //Tightly Coupled
        //private readonly DepartmentRep departmentRep;

        //public DepartmentController1(DepartmentRep departmentRep)
        //{
        //    this.departmentRep = departmentRep;
        //}
        


        // That We How Achive Dependency Injection
       

        public IActionResult Index(string SearchValue = null)
        {

            
            #region Test

            //ViewData["viewdata"] = "Hi , I'm ViewData";
            //ViewBag.viewbag = "Hi , I'm ViewBag";
            //TempData["tempdata"] = "Hi, I'm TempData";

            //string[] Names = {"Ahmed ", "Omer", "Yousef", "Doha"};
            //ViewBag.Data = Names;
            //return RedirectToAction("Index","DepartmentController1");



            //var emp1 = new Employee() { Id = 1 , Name = "Ahmed" ,Salary = 8000};
            //var emp2 = new Employee() { Id = 2, Name = "Omer", Salary = 10000 };
            //var emp3 = new Employee() { Id = 3, Name = "Yousef", Salary = 12000 };
            //var emp4 = new Employee() { Id = 4, Name = "Doha", Salary = 5000 };




            //ViewBag.data = list;

            #endregion

            if (string.IsNullOrEmpty(SearchValue))
            {
                var data = departmentRep.Get();

                return View(data);
            }
            else
            {
               var data= departmentRep.SearchByName(SearchValue);
                return View(data);
                

            }


            
        }

        //This Action Just for Form View 
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var data = departmentRep.GetById(id);
            return View(data);
        }

        //This Action responsibility for Receive Data Return From The [Form] 
        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {

                if (ModelState.IsValid) //Using Validation
                {
                    departmentRep.Create(model);

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            var olddata = departmentRep.GetById(id);

            return View(olddata);
            
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    departmentRep.Edit(model);
                    return RedirectToAction("Index");
                }
              
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var olddata = departmentRep.GetById(id);

            return View(olddata);
        }

            [HttpPost]
        public IActionResult Delete( DepartmentVM model)
        {

            try
            {

                departmentRep.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            { 
                return View();
            }

            
        }

        
    }
}
