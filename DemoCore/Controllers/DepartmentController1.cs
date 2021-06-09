using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.BLL.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

namespace DemoCore.Controllers
{
    public class DepartmentController1 : Controller
    {
        private readonly DepartmentRep _departmentRep = new DepartmentRep();



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
                var data = _departmentRep.Get();
                return View(data);
            }
            else
            {
               var data= _departmentRep.SearchByName(SearchValue);
                return View(data);
                Console.WriteLine("hELLO");
                Console.WriteLine("hELLO");
                Console.WriteLine("hELLO");

            }

            
           
        }

        //This Action Just for Form View 
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var data = _departmentRep.GetById(id);
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
                    _departmentRep.Create(model);

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            var olddata = _departmentRep.GetById(id);

            return View(olddata);
            
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    _departmentRep.Edit(model);
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
            var olddata = _departmentRep.GetById(id);

            return View(olddata);
        }

            [HttpPost]
        public IActionResult Delete( DepartmentVM model)
        {

            try
            {
                
                _departmentRep.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }

            
        }

        
    }
}
