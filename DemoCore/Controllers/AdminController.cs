using DemoCore.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> manager;

        public AdminController(RoleManager<IdentityRole> manager )
        {
            this.manager = manager;
        }



        public IActionResult Index()
        {

            var data = manager.Roles;

            return View(data);
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>CreateRole(CreateRoleVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var User = new IdentityRole()
                    {
                        Name = model.RoleName
                    };

                    var data = await manager.CreateAsync(User);

                    if (data.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    foreach (var errors in data.Errors)
                    {
                        ModelState.AddModelError(" ", errors.Description);
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }

          

        }

      //Get
        public async Task<IActionResult>EditRole(string Id)
        {

          var OldRole =  await manager.FindByIdAsync(Id);

            var NewRole = new EditRoleVM()
            {
                Id = OldRole.Id,
                Name = OldRole.Name
            };


            return View(NewRole);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    var role = await manager.FindByIdAsync(model.Id);

                    role.Name = model.Name;

                    var result = await manager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }

        }

        //Get
        public async Task<IActionResult> DeleteRole(string Id)
        {

            var OldRole = await manager.FindByIdAsync(Id);

            var NewRole = new DeleteRoleVM()
            {
                Id = OldRole.Id,
                Name = OldRole.Name
            };


            return View(NewRole);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRole(DeleteRoleVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var role = await manager.FindByIdAsync(model.Id);

                    role.Name = model.Name;

                    var result = await manager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }

        }
    }
}
