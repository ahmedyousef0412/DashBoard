using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Areas.Purchases.Controllers
{

    [Area("Purchases")]
    public class BillsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
