using Lekadex.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lekadex.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View(TEMPORARYStaticDatabase.Doctors);
        }
        public IActionResult View(int indexOfDoctor)
        {
            return RedirectToAction("Index", "Prescription", TEMPORARYStaticDatabase.Doctors[indexOfDoctor]);
        }
        public IActionResult Delete(int indexOfDoctor)
        {
            return View(TEMPORARYStaticDatabase.Doctors);
        }
    }
}
