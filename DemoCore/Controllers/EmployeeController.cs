using AutoMapper;
using DemoCore.BLL.Helper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoCore.Controllers
{

    public class EmployeeController : Controller
    {

        #region Field
        private readonly IEmployeeRep employeeRep;
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;
        private readonly ICountryRep countryRep;
        private readonly ICityRep cityRep;
        private readonly IDistricRep districRep;


        #endregion


        #region Ctor
        public EmployeeController(IEmployeeRep employeeRep,
           IDepartmentRep departmentRep, IMapper mapper,
           ICountryRep countryRep, ICityRep cityRep
           , IDistricRep districRep)
        {
            this.employeeRep = employeeRep;
            this.departmentRep = departmentRep;
            this.mapper = mapper;
            this.countryRep = countryRep;
            this.cityRep = cityRep;
            this.districRep = districRep;
        }
        #endregion



        #region Actions
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
           
            //department have All item in Entity Department and i will loop on it in[view] 

            
            ViewBag.department = new SelectList(departmentRep.Get() ,"Id", "DepartmentName");

            ViewBag.country = new SelectList(countryRep.Get(), "Id", "Name");


            return View();
        }



        [HttpPost]
        public IActionResult Create(EmployeeVM employee)
        {
            try
            {
                if(ModelState.IsValid)
                {


                    var CvUrl = UploaderHelper.UploadFile("Files/Docs", employee.CV);
                    var ImgUrl = UploaderHelper.UploadFile("Files/Imags", employee.Photo);

                    var result = mapper.Map<Employee>(employee);

                    result.CvUrl = CvUrl;
                    result.PhotoUrl = ImgUrl;


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



     
        public IActionResult Edit(int id)
        {
            var data = employeeRep.GetById(id);

            var result = mapper.Map<EmployeeVM>(data);

            var depart = departmentRep.Get();

            ViewBag.department = new SelectList(depart,"Id","DepartmentName", data.DepartmentId);
            ViewBag.country = new SelectList(countryRep.Get(), "Id", "Name");
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(employee);
                    employeeRep.Edit(data);
                    return RedirectToAction("Index","Employee");
                }

                else
                {
                    return View(employee);
                }


            }
            catch (Exception )
            {
                
                return View();

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


                UploaderHelper.RemoveFile("Files/Docs/", employee.CvUrl);
                UploaderHelper.RemoveFile("Files/Imags/", employee.PhotoUrl);

                var oldData = employeeRep.GetById(employee.Id);
                
                employeeRep.Delete(oldData);
                return RedirectToAction("Index");
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
        #endregion



        #region Ajax Call


        [HttpPost]
   
        public JsonResult GetCityDataByCountryId(int CtryId)
        {

            var data = cityRep.Get().Where(c => c.CountryId == CtryId);

            var map = mapper.Map<IEnumerable<CityVM>>(data);

            return Json(map);
           
            

        }
        [HttpPost]
        public JsonResult GetDistrictByCityId(int CtyId)
        {
            var data = districRep.Get().Where(d => d.CityId == CtyId);

            var map = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(map);
        }



        #endregion
    }
}
