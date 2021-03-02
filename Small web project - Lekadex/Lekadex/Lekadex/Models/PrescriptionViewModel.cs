using System;
using System.Collections.Generic;

namespace Lekadex
{ 
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public IEnumerable<PrescriptionViewModel> MedicinesList { get; set; }
    }
}
