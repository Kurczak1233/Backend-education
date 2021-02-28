using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lekadex
{
    public static class TEMPORARYStaticDatabase
    {
        public static List<DoctorViewModel> Doctors => new List<DoctorViewModel>
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
    }
}
