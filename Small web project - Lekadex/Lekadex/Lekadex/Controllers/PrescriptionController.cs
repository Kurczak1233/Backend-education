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
        public IActionResult Index(int indexOfDoctor, string filterString)
        {
            IndexOfDoctor = indexOfDoctor;

            if (string.IsNullOrEmpty(filterString))
            {
                return View(TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor));
            }
            return View(new DoctorViewModel {
                Name = TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor).Name,
                Prescriptions = TEMPORARYStaticDatabase.Doctors.ElementAt(indexOfDoctor).Prescriptions.Where(x=>x.Name.Contains(filterString)).ToList()
            });
        }
        public IActionResult View(int indexOfPrescription)
        {
            return RedirectToAction("Index", "Medicine", new { indexOfDoctor = IndexOfDoctor, indexOfPrescription = indexOfPrescription });
        }
        public IActionResult Delete(int indexOfPrescription)
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVM)
        {
            TEMPORARYStaticDatabase.Doctors.ElementAt(IndexOfDoctor).Prescriptions.Add(prescriptionVM);
            return RedirectToAction("Index");
        }
    }
}
