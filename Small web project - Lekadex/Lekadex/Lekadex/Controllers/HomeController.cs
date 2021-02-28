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
        public List<DoctorViewModel> Doctors => new List<DoctorViewModel>
        {
                new DoctorViewModel
                {
                    Name = "Patryk",
                    Prescriptions = new List<PrescriptionViewModel>
                    {
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 1",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Magnez",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Aspiryna",
                                }
                            }
                        },
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 2",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Lek inny",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Cokolwiek",
                                }
                            }
                        }
                    }

                },
                new DoctorViewModel
                {
                    Name = "Kazimierz",
                    Prescriptions = new List<PrescriptionViewModel>
                    {
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 1",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Magnez",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Aspiryna",
                                }
                            }
                        },
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 2",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Lek inny",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Cokolwiek",
                                }
                            }
                        }
                    }
                },
                new DoctorViewModel
                {
                    Name = "Zbigniew",
                    Prescriptions = new List<PrescriptionViewModel>
                    {
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 1",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Magnez",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Aspiryna",
                                }
                            }
                        },
                        new PrescriptionViewModel
                        {
                            Name = "Recepta 2",
                            Medicines = new List<MedicineViewModel>
                            {
                                new MedicineViewModel
                                {
                                    Name = "Lek inny",
                                },
                                new MedicineViewModel
                                {
                                    Name = "Cokolwiek",
                                }
                            }
                        }
                    }
                }

        };
        public IActionResult Index()
        {
            return View(Doctors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
