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
    public class MedicineController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MedicineController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int indexOfDoctor, int indexOfPrescription, string filterString)
        {
            if (string.IsNullOrEmpty(filterString))
            {
                return View(TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription));
            }
            return View(new PrescriptionViewModel
            {
                Name = TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription).Name,
                Medicines = TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.ElementAt(indexOfPrescription).Medicines.Where(c => c.Name.Contains(filterString)).ToList()
            });
        }

        public IActionResult Delete(int indexOfMedicine)
        {
            return View();
        }
    }
}
