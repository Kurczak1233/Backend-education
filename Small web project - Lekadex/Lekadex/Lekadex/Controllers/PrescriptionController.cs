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
    public class PrescriptionController : Controller
    {
        private int IndexOfDoctor { get; set; }
        private DoctorViewModel _DoctorVM { get; set; }
        public IActionResult Index(int indexOfDoctor)
        {
            IndexOfDoctor = indexOfDoctor;
            return View(TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor));
        }
        public IActionResult View(int indexOfPrescription)
        {
            return RedirectToAction("Index", "Medicine", new { indexOfDoctor = IndexOfDoctor, indexOfPrescription = indexOfPrescription });
        }
        public IActionResult Delete(int indexOfPrescription)
        {
            return View();
        }
    }
}
