﻿using Lekadex.Core;
using Lekadex.Core.DTOs;
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
            prescriptionViewModel.MedicinesList = (IEnumerable<PrescriptionViewModel>)_VMMapper.Map(medicineDtos);
            return View(prescriptionViewModel);
        }

        public IActionResult Delete(int indexOfMedicine)
        {
            _DoctorManager.DeleteMedicine(new MedicineDto { Id = indexOfMedicine }); //W naszym repo porównujemy tylko ID, więć dając ID to zadziała

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVM)
        {
            var dto = _VMMapper.Map(medicineVM);
            _DoctorManager.AddNewMedicine(dto, PrescriptionId);
            return RedirectToAction("Index");
        }
    }
}
