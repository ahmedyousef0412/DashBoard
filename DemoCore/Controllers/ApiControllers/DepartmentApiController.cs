using AutoMapper;
using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Models.ViewModels;
using DemoCore.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoCore.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {

        #region Field
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper mapper;

        #endregion

        #region Ctor
        public DepartmentApiController(IDepartmentRep departmentRep, IMapper mapper)
        {
            this.departmentRep = departmentRep;
            this.mapper = mapper;
        }
        #endregion

        #region Actions


        [HttpGet]
        [Route("GetAllDepts")]
        public IActionResult GetDepts()
        {

            try
            {
                var data = departmentRep.Get();
                return Ok(data);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        [HttpPost]
        [Route("AddDept")]
        public IActionResult CreateDept(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);

                    departmentRep.Create(data);

                    var getAll = departmentRep.Get();
                    return Ok(getAll);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }

        }





        [HttpPut]
        [Route("EditDept")]
        public IActionResult EditDept(DepartmentVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var map = mapper.Map<Department>(model);

                    departmentRep.Edit(map);

                    var getAll = departmentRep.Get();

                    return Ok(getAll);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
               
            }
        }





        [HttpDelete]
        [Route("DeleteDept")]
        public IActionResult DeleteDept(DepartmentVM model)
        {
            try
            {
               if(ModelState.IsValid)
                {

                    var data = departmentRep.GetById(model.Id);

                    departmentRep.Delete(data);

                    var getAll = departmentRep.Get();
                    return Ok(getAll);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public IActionResult DeleteDept(int id)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    var data = departmentRep.GetById(id);

                    departmentRep.Delete(data);
                    var getAll = departmentRep.Get();

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
