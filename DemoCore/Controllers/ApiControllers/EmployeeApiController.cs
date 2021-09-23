using AutoMapper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
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
        public EmployeeApiController(IEmployeeRep employeeRep,
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

        [HttpGet]
        [Route("Employee")]
        public IActionResult GetAllEmp()
        {

            try
            {
                var data = employeeRep.Get();

                return Ok(data);
            }
            catch (Exception)
            {

                return NotFound();
            }
            

        }

        [HttpPost]
        public IActionResult CreateEmp(EmployeeVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var map = mapper.Map<Employee>(model);

                    employeeRep.Create(map);

                    var getAll = employeeRep.Get();

                    return Ok(getAll);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }
          

        }
        #endregion
    }
}
