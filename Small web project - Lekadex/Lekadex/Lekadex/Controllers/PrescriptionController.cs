using Lekadex.Core;
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
    public class PrescriptionController : Controller
    {

        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _VMMapper;

        public PrescriptionController(IDoctorManager docmanager, ViewModelMapper vmMapper)
        {
            _DoctorManager = docmanager;
            _VMMapper = vmMapper;
        }
        private int DoctorId { get; set; }
        private DoctorViewModel _DoctorVM { get; set; }
        public IActionResult Index(int doctorId, string filterString)
        {
            DoctorId = doctorId;
            var prescriptionDto = _DoctorManager.GetAllPrescriptionsForADoctor(doctorId, filterString);
            var doctorDto = _DoctorManager.GetAllDoctors(null).FirstOrDefault(x => x.Id == doctorId);
            var DoctorVm = _VMMapper.Map(doctorDto);
            DoctorVm.PresiptionsList = (IEnumerable<PrescriptionViewModel>)_VMMapper.Map(DoctorVm);
            return View();
        }
        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { doctorId = DoctorId, prescriptionId = prescriptionId });
        }
        public IActionResult Delete(int prescriptionID)
        {
            _DoctorManager.DeletePrescription(new PrescriptionDto{ Id = prescriptionID});
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVM)
        {
            var dto = _VMMapper.Map(prescriptionVM);
            _DoctorManager.AddNewPrescription(dto, DoctorId);
            return RedirectToAction("Index");
        }
    }
}
