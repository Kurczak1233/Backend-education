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


        public IActionResult Index(string filterString)
        {
            if (string.IsNullOrEmpty(filterString))
            {
                return View(TEMPORARYStaticDatabase.Doctors);
            }
            return View(TEMPORARYStaticDatabase.Doctors.Where(x=>x.Name.Contains(filterString)).ToList());
        }
        public IActionResult View(int indexOfDoctor)
        {
            return RedirectToAction("Index", "Prescription", new { indexOfDoctor = indexOfDoctor });
        }
        public IActionResult Delete(int indexOfDoctor)
        {
            return View(TEMPORARYStaticDatabase.Doctors);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DoctorViewModel DoctorVM)
        {
            TEMPORARYStaticDatabase.Doctors.Add(DoctorVM);
            return RedirectToAction("Index");
        }
    }
}
