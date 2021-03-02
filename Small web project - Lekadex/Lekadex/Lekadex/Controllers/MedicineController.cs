using Lekadex.Core;
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
        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _VMMapper;
        private int DoctorId { get; set; }
        private int PrescriptionId { get; set; }
        public MedicineController(IDoctorManager docmanager, ViewModelMapper vmMapper)
        {
            _DoctorManager = docmanager;
            _VMMapper = vmMapper;
        }
        public IActionResult Index(int doctorId, int prescriptionId , string filterString)
        {

            var prescriptionDto = _DoctorManager.GetAllPrescriptionsForADoctor(doctorId, null).Where(x=>x.Id == prescriptionId).FirstOrDefault(); // null bo FIltrujemy leki nie preskrypcje
            var medicineDtos = _DoctorManager.GetAllMedicinesForAPrescription(prescriptionId, filterString);
            var prescriptionViewModel = _VMMapper.Map(prescriptionDto);
            prescriptionViewModel.MedicinesList = _VMMapper.Map(medicineDtos);
            DoctorId = doctorId;
            PrescriptionId = prescriptionId;
            if (string.IsNullOrEmpty(filterString))
            {
                return View(TEMPORARYStaticDatabase.Doctors.ElementAt(doctorId).Prescriptions.ElementAt(prescriptionId));
            }
            return View(new PrescriptionViewModel
            {
                Name = TEMPORARYStaticDatabase.Doctors.ElementAt(doctorId).Prescriptions.ElementAt(prescriptionId).Name,
                Medicines = TEMPORARYStaticDatabase.Doctors.ElementAt(doctorId).Prescriptions.ElementAt(prescriptionId).Medicines.Where(c => c.Name.Contains(filterString)).ToList()
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
