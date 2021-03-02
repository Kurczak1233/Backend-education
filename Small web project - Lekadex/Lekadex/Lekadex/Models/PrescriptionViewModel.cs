using System.Collections.Generic;

namespace Lekadex
{ 
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public List<MedicineDto> MedicinesList { get; set; }
    }
}
