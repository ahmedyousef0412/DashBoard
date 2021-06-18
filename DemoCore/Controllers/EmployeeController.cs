using AutoMapper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DemoCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep employeeRep;
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRep employeeRep , IDepartmentRep departmentRep , IMapper mapper)
        {
            this.employeeRep = employeeRep;
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        }
        public IActionResult Index(string SearchValue = null)
        {

            if (string.IsNullOrEmpty(SearchValue))
            {
                var data = employeeRep.Get();
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

                return View(result);
            }
            else
            {
                var data = employeeRep.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }

           
        }
        
        public IActionResult Details(int id)
        {
            var data = employeeRep.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);
            return View(result);
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
                    var result = mapper.Map<Employee>(employee);
                    employeeRep.Create(result);
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
            var result = mapper.Map<EmployeeVM>(data);
            var depart = departmentRep.Get();
            ViewBag.department = new SelectList
                (depart, "Id", "DepartmentName",data.DepartmentId);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var map = mapper.Map<Employee>(employee);
                    employeeRep.Edit(map);
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
            var map = mapper.Map<EmployeeVM>(data);
            var dept = departmentRep.Get();
            ViewBag.department = new SelectList(dept, "Id", "DepartmentName" ,data.DepartmentId);
            return View(map);
        }

        [HttpPost]
        
        public IActionResult Delete(EmployeeVM employee)
        {
            try
            {
                var oldData = employeeRep.GetById(employee.Id);
                
                employeeRep.Delete(oldData);
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
