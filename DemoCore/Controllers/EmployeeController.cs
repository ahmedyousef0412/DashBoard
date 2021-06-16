using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace DemoCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep employeeRep;
        private readonly IDepartmentRep departmentRep;

        public EmployeeController(IEmployeeRep employeeRep , IDepartmentRep departmentRep)
        {
            this.employeeRep = employeeRep;
            this.departmentRep = departmentRep;
        }
        public IActionResult Index(string SearchValue = null)
        {

            if (string.IsNullOrEmpty(SearchValue))
            {
                var data = employeeRep.Get();
                return View(data);
            }
            else
            {
                var data = employeeRep.SearchByName(SearchValue);
                return View(data);
            }

           
        }
        
        public IActionResult Details(int id)
        {
            var data = employeeRep.GetById(id);
            return View(data);
        }
        
        public IActionResult Create()
        {
            /*
             Here I'm Using [ departmentRep.Get()] because I want to 
            when i open the page of Create it will be Empty but i need the 
            [DropDownList have data from [Department]
             
             */
            var data = departmentRep.Get();
            
            //department have All item in Entity Department and i will loop on it in[view] 
            ViewBag.department = new SelectList(data, "Id", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employee)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    employeeRep.Create(employee);
                    return RedirectToAction("Index","Employee");
                }
                //else
                var data = departmentRep.Get();
                ViewBag.department = new SelectList(data, "Id", "DepartmentName",employee.DepartmentId);
                return View(employee);
            }
            catch (Exception )
            {
                //EventLog log = new();
                //log.Source = "Admin DashBoard";
                //log.WriteEntry(e.Message, EventLogEntryType.Error);
                return View(employee);
                
            }

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = employeeRep.GetById(id);
            var depart = departmentRep.Get();
            ViewBag.department = new SelectList
                (depart, "Id", "DepartmentName",data.DepartmentId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeRep.Edit(employee);
                    return RedirectToAction("Index", "Employee");
                }
                var dept = departmentRep.Get();
                ViewBag.department = new SelectList(dept, "Id", "DepartmentName", employee.DepartmentId);

                return View(employee);
                
                
            }
            catch (Exception )
            {
                //EventLog log = new();
                //log.Source = "Admin DashBoard";
                //log.WriteEntry(e.Message, EventLogEntryType.Error);
                return View(employee);

            }

        }

        public IActionResult Delete(int id)
        {
            var data = employeeRep.GetById(id);
            var dept = departmentRep.Get();
            ViewBag.department = new SelectList(dept, "Id", "DepartmentName" ,data.DepartmentId);
            return View(data);
        }

        [HttpPost]
        
        public IActionResult Delete(EmployeeVM employee)
        {
            try
            {
                employeeRep.Delete(employee.Id);
                return RedirectToAction("Index","Employee");
            }
            catch (Exception )
            {

                //EventLog log = new();
                //log.Source = "Admin DashBoard";
                //log.WriteEntry(e.Message, EventLogEntryType.Error);
                //return View(employee);
                return View();

            }
        }
       
    }
}
