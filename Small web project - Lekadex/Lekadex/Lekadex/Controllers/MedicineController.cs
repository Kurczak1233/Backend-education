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
        private int IndexOfDoctor { get; set; }
        private int IndexOfPrescription { get; set; }
        public IActionResult Index(int indexOfDoctor, int indexOfPrescription, string filterString)
        {
            IndexOfDoctor = indexOfDoctor;
            IndexOfPrescription = indexOfPrescription;
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

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVM)
        {
            TEMPORARYStaticDatabase.Doctors.ElementAt(IndexOfDoctor).Prescriptions.ElementAt(IndexOfPrescription).Medicines.Add(medicineVM);
            return RedirectToAction("Index");
        }
    }
}
