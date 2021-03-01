using Lekadex.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lekadex.Core.DTOs
{
    public class PrescriptionDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DoctorDto Doctor { get; set; }
        public  List<MedicineDto> MedicinesList { get; set; }
    }
}
