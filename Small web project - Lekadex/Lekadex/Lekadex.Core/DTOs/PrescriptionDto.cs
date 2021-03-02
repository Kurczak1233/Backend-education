using System;
using System.Collections.Generic;

namespace Lekadex.Core.DTOs
{
    public class PrescriptionDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public IEnumerable<MedicineDto> MedicinesList { get; set; }
    }
}
