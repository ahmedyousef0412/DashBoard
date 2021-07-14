using DemoCore.BLL.Helper;
using DemoCore.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMail(MailVM mail)
        {
            var Send = MailSender.SendMail(mail);
            TempData["Msg"] = Send;
            return View();
        }
    }
}
