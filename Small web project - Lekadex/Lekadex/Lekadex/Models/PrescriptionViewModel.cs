using System.Collections.Generic;

namespace Lekadex
{ 
    public class PrescriptionViewModel
    {
        public string Name { get; set; }
        public List<MedicineViewModel> Medicines { get; set; }
    }
}
