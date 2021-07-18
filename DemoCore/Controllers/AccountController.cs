using DemoCore.BLL.Models;
using DemoCore.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> manager, 
            SignInManager<IdentityUser> signIn ,
            ILogger<AccountController> logger)
        {
            this.manager = manager;
            this.signIn = signIn;
            this.logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
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

                    // Check If Account Used Before Create Another Have The Same Name
                    var IsFound = await manager.FindByEmailAsync(model.Email);
                    if(IsFound == null)
                    {
                        var User = new IdentityUser()
                        {
                            UserName = model.UserName,
                            Email = model.Email

                        };
                        // CreateAsync [Take From me] [Password] and Hashed It.
                        var Result = await manager.CreateAsync(User, model.Password);

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
                    else
                    {
                        ModelState.AddModelError("", "This Email Are Used Before...");
                    }
                   

                    
                }
                
                    return View(model);
                
            }
            catch (Exception)
            {

                return View(model);
            }

           
           
           
            
        }


        // Get

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var data = await signIn.PasswordSignInAsync
                        (model.Email, model.Password, model.RememberMe, false);

                    if (data.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                    
                    else
                    {
                        
                        ModelState.AddModelError(" ", "Invaild UserName Or Password");
                    }
                }
                //Else

                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {

            await signIn.SignOutAsync();
            return RedirectToAction("Login");
        }


        //Get
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public  async Task< IActionResult> ForgetPassword(ForgetPasswordVM model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    // Search On Email
                    var user = await manager.FindByEmailAsync(model.Email);


                    // check if Email find or Not
                    if(user != null)
                    {

                        //Generate Token with Email like[goeddlduyqecshnnlajja@gmail.comhhhmhmhjgffg]
                        var token = await manager.GeneratePasswordResetTokenAsync(user);

                        // Like [ var path = "Localhost :1235//Account / ResetPassword"]
                        var PasswordLink =  Url.Action("ResetPassword", "Account", 
                            new { Email = model.Email, Token = token }, Request.Scheme);



                        //Find AnY message In Windows  Like [Event Viewer] but this is [Core]
                        // Instead Logger I Can Use [SendMail]
                        logger.Log(LogLevel.Warning, PasswordLink);

                        return RedirectToAction("ConfirmForgetPassword");

                    }
                    return RedirectToAction("ConfirmForgetPassword");



                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
           
        }



        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }




        public IActionResult ResetPassword(string Email , string Token)

        {

            if(Email == null || Token ==null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    var user = await manager.FindByEmailAsync(model.Email);


                    if(user != null) 
                    {
                        var result =await manager.ResetPasswordAsync(user, model.Token, model.Password);

                        if(result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPassword");
                        }
                        foreach (var errors in result.Errors)
                        {
                            ModelState.AddModelError(" ", errors.Description);
                        }

                        return View(model);
                    }
                    return RedirectToAction("ConfirmResetPassword");

                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }


        }

        public IActionResult ConfirmResetPassword()
        {
            return View();
        }

    }
}
