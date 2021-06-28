using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Areas.Inventory.Controllers
{

    [Area("Inventory")]
    public class StorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
