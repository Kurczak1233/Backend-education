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
    public class HomeController : Controller
    {

        private readonly IDoctorManager _DoctorManager;
        private readonly ViewModelMapper _VMMapper;
        public HomeController(IDoctorManager docmanager, ViewModelMapper vmMapper)
        {
            _DoctorManager = docmanager;
            _VMMapper = vmMapper;
        }
        public IActionResult Index(string filterString)
        {
            var DoctorsDTO = _DoctorManager.GetAllDoctors(filterString);
            var DoctorViewModel = _VMMapper.Map(DoctorsDTO);
            return View(DoctorViewModel);
        }
        public IActionResult View(int doctorId)
        {
            return RedirectToAction("Index", "Prescription", new { doctorId = doctorId });
        }
        public IActionResult Delete(int doctorId)
        {
            _DoctorManager.DeleteDoctor(new DoctorDto { Id = doctorId });
            var DoctorsDTO = _DoctorManager.GetAllDoctors(null); //Zwracamy wszystkich pozostałych doktorów.
            var DoctorViewModel = _VMMapper.Map(DoctorsDTO);
            return View("Index", DoctorViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DoctorViewModel DoctorVM)
        {
            var dto = _VMMapper.Map(DoctorVM);
            _DoctorManager.AddNewDoctor(dto);
            return RedirectToAction("Index");
        }
    }
}
