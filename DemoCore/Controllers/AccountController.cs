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
//    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> manager;
        private readonly SignInManager<IdentityUser> signIn;

        public AccountController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signIn)
        {
            this.manager = manager;
            this.signIn = signIn;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        // Get
      
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task <IActionResult>Login(LoginVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {

                    var data = await signIn.PasswordSignInAsync
                        (model.UserName, model.Password, model.RememberMe, false);

                    if(data.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError(" ","Invaild UserName Or Password");
                    }
                }
                else
                {
                    return View(model);
                }

                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
           
        }

        [HttpPost]
        public async Task <IActionResult> LogOut()
        {

            await signIn.SignOutAsync();
            return RedirectToAction("Login");
        }




        // Get
        public IActionResult Registeration()
        {
            return View();
        }

        
        [HttpPost]
        public async Task< IActionResult> Registeration(RegistrationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var User = new IdentityUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email

                    };

                    // CreateAsync [Take From me] [Password] and Hashed It.
                    var Result = await manager.CreateAsync(User ,model.Password);

                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var Errors in Result.Errors)
                        {
                            ModelState.AddModelError(" ", Errors.Description);
                        }
                    }
                }
                
                    return View(model);
                
            }
            catch (Exception)
            {

                return View(model);
            }

           
           
           
            
        }
       
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

    }
}
